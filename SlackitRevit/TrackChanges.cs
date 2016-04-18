#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion

namespace TrackChanges
{
    [Transaction(TransactionMode.ReadOnly)]
    public class Command : IExternalCommand
    {
        #region String formatting
        /// <summary>
        /// Convert a string to a byte array.
        /// </summary>
        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length
              * sizeof(char)];

            System.Buffer.BlockCopy(str.ToCharArray(),
              0, bytes, 0, bytes.Length);

            return bytes;
        }

        
        /// <summary>
        /// Return a string describing the given element:
        /// .NET type name,
        /// category name,
        /// family and symbol name for a family instance,
        /// element id and element name.
        /// </summary>
        public static string ElementDescription(
          Element e)
        {
            if (null == e)
            {
                return "<null>";
            }

            // For a wall, the element name equals the
            // wall type name, which is equivalent to the
            // family name ...

            FamilyInstance fi = e as FamilyInstance;

            string typeName = e.GetType().Name;

            string categoryName = (null == e.Category)
              ? string.Empty
              : e.Category.Name + " ";

            string familyName = (null == fi)
              ? string.Empty
              : fi.Symbol.Family.Name + " ";

            string symbolName = (null == fi
              || e.Name.Equals(fi.Symbol.Name))
                ? string.Empty
                : fi.Symbol.Name + " ";

            return string.Format("{0} {1}{2}{3}<{4} {5}>",
              typeName, categoryName, familyName,
              symbolName, e.Id.IntegerValue, e.Name);
        }

        public static string ElementDescription(
          Document doc,
          int element_id)
        {
            return ElementDescription(doc.GetElement(
              new ElementId(element_id)));
        }
        #endregion // String formatting

        #region Retrieve elements of interest
        /// <summary>
        /// Retrieve all elements to track.
        /// It is up to you to decide which elements
        /// are of interest to you.
        /// </summary>
        public static IEnumerable<Element> GetTrackedElements(
          Document doc)
        {
            Categories cats = doc.Settings.Categories;

            List<ElementFilter> a = new List<ElementFilter>();

            foreach (Category c in cats)
            {
                if (CategoryType.Model == c.CategoryType || CategoryType.Annotation == c.CategoryType)
                {
                    a.Add(new ElementCategoryFilter(c.Id));
                }
            }

            ElementFilter isModelCategory
              = new LogicalOrFilter(a);


            Options opt = new Options();

            return new FilteredElementCollector(doc)
              .WhereElementIsNotElementType()
              .WhereElementIsViewIndependent()
              .WherePasses(isModelCategory)
              .Where<Element>(e => e.Pinned == true);
        }
        #endregion // Retrieve elements of interest

        #region Store element state
        /// <summary>
        /// Return a string representing the given element
        /// state. This is the information you wish to track.
        /// It is up to you to ensure that all data you are
        /// interested in really is included in this snapshot.
        /// In this case, we ignore all elements that do not
        /// have a valid bounding box.
        /// </summary>
        public static string GetElementState(Element e)
        {
            string s = null;
            s = string.Join("Element:", ElementDescription(e));
            return s;
        }
        #endregion // Store element state

        #region Creating a Database State Snapshot
        /// <summary>
        /// Return a dictionary mapping element id values
        /// to hash codes of the element state strings. 
        /// This represents a snapshot of the current 
        /// database state.
        /// </summary>
        public static Dictionary<int, string> GetSnapshot(
          IEnumerable<Element> a)
        {
            Dictionary<int, string> d
              = new Dictionary<int, string>();

            SHA256 hasher = SHA256Managed.Create();

            foreach (Element e in a)
            {
                //Debug.Print( e.Id.IntegerValue.ToString() 
                //  + " " + e.GetType().Name );

                string s = GetElementState(e);

                if (null != s)
                {
                    string hashb64 = Convert.ToBase64String(
                      hasher.ComputeHash(GetBytes(s)));

                    d.Add(e.Id.IntegerValue, hashb64);
                }
            }
            return d;
        }
        #endregion // Creating a Database State Snapshot

        #region Report differences
        /// <summary>
        /// Compare the start and end states and report the 
        /// differences found. In this implementation, we
        /// just store a hash code of the element state.
        /// If you choose to store the full string 
        /// representation, you can use that for comparison,
        /// and then report exactly what changed and the
        /// original values as well.
        /// </summary>
        public static string ReportDifferences(
          Document doc,
          Dictionary<int, string> start_state,
          Dictionary<int, string> end_state)
        {
            int n1 = start_state.Keys.Count;
            int n2 = end_state.Keys.Count;

            List<int> keys = new List<int>(start_state.Keys);

            foreach (int id in end_state.Keys)
            {
                if (!keys.Contains(id))
                {
                    keys.Add(id);
                }
            }

            keys.Sort();

            int n = keys.Count;

            Debug.Print(
              "{0} elements before, {1} elements after, {2} total",
              n1, n2, n);

            int nAdded = 0;
            int nUnpinned = 0;
            int nDeleted = 0;
            int nIdentical = 0;
            List<string> report = new List<string>();

            foreach (int id in keys)
            {
                if (!start_state.ContainsKey(id))
                {
                    ++nAdded;
                    report.Add("Element ID " + id.ToString() + " pinned:  "
                      + ElementDescription(doc, id));
                }
                else if ("<null>" == ElementDescription(doc, id))
                {
                    ++nDeleted;
                    report.Add("Element ID " + id.ToString() + " deleted");
                }
                else if (!end_state.ContainsKey(id))
                {
                    ++nUnpinned;
                    report.Add("Element ID " + id.ToString() + " unpinned:  " + ElementDescription(doc, id));

                }
                else
                {
                    ++nIdentical;
                }
            }

            string msg = string.Format(
              "{0} pinned, {1} unpinned, "
              + "{2} deleted, {3} identical elements:",
              nAdded, nUnpinned, nDeleted, nIdentical);

            string s = string.Join("\r\n", report);

            string slack = msg + "\n" + s;
            Debug.Print(msg + "\r\n" + s);
            //TaskDialog dlg = new TaskDialog( "Track Changes" );
            //dlg.MainInstruction = msg;
            //dlg.MainContent = s;
            //dlg.Show();
            return slack;
        }
        #endregion // Report differences

        /// <summary>
        /// Current snapshot of database state.
        /// You could also store the entire element state 
        /// strings here, not just their hash code, to
        /// report their complete original and modified 
        /// values.
        /// </summary>
        public static Dictionary<int, string> _start_state = null;

        #region External Command Mainline Execute Method
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            IEnumerable<Element> a = GetTrackedElements(doc);

            if (null == _start_state)
            {
                _start_state = GetSnapshot(a);
            }
            else
            {
                Dictionary<int, string> end_state = GetSnapshot(a);
                ReportDifferences(doc, _start_state, end_state);
                _start_state = null;
            }
            return Result.Succeeded;
        }
        #endregion // External Command Mainline Execute Method
    }
}