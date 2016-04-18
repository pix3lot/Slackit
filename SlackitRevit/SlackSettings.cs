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
           
            return Result.Succeeded;
        }
    }

    public class SlackSettings
    {
        public bool slackOn;
        public bool giphyOn;
        public string slackCh;
        public string slackChId;
        public string slackToken;
    }
}