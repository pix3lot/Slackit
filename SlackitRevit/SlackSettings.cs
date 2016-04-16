using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Slack;
using Newtonsoft.Json;

namespace SlackitRevit
{
    public class Settings : IExternalCommand
    {
        
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            if (doc.IsFamilyDocument)
            {
                TaskDialog.Show("Exception", "These settings can only be saved to a Revit project, not in a family file.");
            }
           // DefinitionFile sharedParamDefFile = SharedParam.GetSharedParamFile(app, sharedParameterFilePath);
           
            return Result.Succeeded;
        }
    }

    //public class SharedParam
    //{
    //    public static DefinitionFile GetSharedParamFile(Autodesk.Revit.ApplicationServices.Application app, string sharedParamsFilePath)
    //    {
    //        string sharedParamsFileName;
    //        sharedParamsFileName = app.SharedParametersFilename;

    //        if (sharedParamsFileName.Length > 0)
    //        {
    //            return app.OpenSharedParameterFile();
    //        }
    //        else
    //        {
    //            string path = sharedParamsFilePath;
    //            StreamWriter stream;
    //            stream = new StreamWriter(path);
    //            stream.Close();

    //            app.SharedParametersFilename = path;
    //            sharedParamsFileName = app.SharedParametersFilename;

    //            return app.OpenSharedParameterFile();
    //        }

    //    }

    //    public static DefinitionGroup GetOrCreateSharedParamsGroup(DefinitionFile sharedParametersFile, string groupName)
    //    {
    //        DefinitionGroups gs = sharedParametersFile.Groups;

    //        DefinitionGroup g = gs.get_Item(groupName);

    //        if (null == g)
    //        {
    //            try
    //            {
    //                g = gs.Create(groupName);
    //            }
    //            catch (Exception e)
    //            {
    //                string message = "Error binding shared parameter: " + e.Message;

    //                TaskDialog.Show("Exception", message);
    //            }
    //        }

    //        return g;
    //    }

    //    public static Definition GetOrCreateSharedParamsDefinition(DefinitionGroup defGroup, ParameterType defType, string defName, bool visible)
    //    {
    //        ExternalDefinitonCreationOptions options = new ExternalDefinitonCreationOptions(defName, defType);

    //        options.Visible = visible;

    //        Definition def = defGroup.Definitions.get_Item(defName);

    //        if (null == def)
    //        {
    //            try
    //            {
    //                def = defGroup.Definitions.Create(options);
    //            }
    //            catch (Exception)
    //            {
    //                def = null;
    //            }
    //        }

    //        return def;
    //    }

    //    public static Guid SharedParamGUID(Application app, string defGroup, string defName)
    //    {
    //        Guid guid = Guid.Empty;
    //        try
    //        {
    //            DefinitionFile file = app.OpenSharedParameterFile();
    //            DefinitionGroup group = file.Groups.get_Item(defGroup);
    //            Definition definition = group.Definitions.get_Item(defName);
    //            ExternalDefinition externalDefinition = definition as ExternalDefinition;
    //            guid = externalDefinition.GUID;
    //        }
    //        catch (Exception)
    //        {

    //        }
    //        return guid;
    //    }

    //    public static void SetParameter(Application app, Document doc, string defname, string p_inst)
    //    {
    //        DefinitionFile defFile = GetSharedParamFile(app, Variables.spFilePath);
    //        DefinitionGroup defGroup = GetOrCreateSharedParamsGroup(defFile, Variables.groupName);
    //        Definition defId = GetOrCreateSharedParamsDefinition(defGroup, ParameterType.Text, defname, false);

    //        //Bind Definitions
    //        Transaction t = new Transaction(doc);
    //        t.Start("Bind Parameter");

    //        try
    //        {
    //            CategorySet catSet = app.Create.NewCategorySet();
    //            catSet.Insert(doc.Settings.Categories.get_Item(BuiltInCategory.OST_ProjectInformation));
    //            Binding binding = app.Create.NewInstanceBinding(catSet);
    //            doc.ParameterBindings.Insert(defId, binding);
    //        }
    //        catch (Exception ex)
    //        {
    //            string message = "Error binding shared parameter: " + ex.Message;
    //            TaskDialog.Show("Exception", message);
    //        }

    //        t.Commit();

    //        Element projInfoElem = Collectors.GetProjectInfoElem(doc);

    //        if (null == projInfoElem)
    //        {
    //            string message = "No project info elem found. Aborting command...";
    //            TaskDialog.Show("Exception", message);
    //        }

    //        t.Start("Set parameters to element");

    //        projInfoElem.LookupParameter(defname).Set(p_inst);

    //        t.Commit();
    //    }

    //    public static class Collectors
    //    {
    //        public static Element GetProjectInfoElem(Document doc)
    //        {
    //            FilteredElementCollector col = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_ProjectInformation);
    //            Element e = col.FirstElement();
    //            return e;
    //        }
    //    }

    //}

    public class SlackSettings
    {
        public bool slackOn;
        public bool giphyOn;
        public string slackCh;
        public string slackChId;
        public string slackToken;
    }
}