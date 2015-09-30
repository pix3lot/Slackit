#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Interop;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
//using Autodesk.Revit.UI.Selection;
//using Autodesk.Revit.DB.ExtensibleStorage;
using Slack;
using RestSharp;
using Newtonsoft.Json;

#endregion

namespace SlackitRevit
{
    [Transaction(TransactionMode.Manual)]

    public class SlackCommand : IExternalCommand
    {
        //public static List<string> chlist { get; set; }
        //public static Dictionary<string, string> chdict { get; set; }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            SlackForm form = new SlackForm();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                Document doc = commandData.Application.ActiveUIDocument.Document;
                Autodesk.Revit.ApplicationServices.Application app = doc.Application;

                if (doc.IsFamilyDocument)
                {
                    TaskDialog.Show("Exception", "These settings can only be saved while in a Revit project, not in a Family.");
                }

                SlackSettings s = new SlackSettings();
                s.slackCh = Variables.slackCh;
                s.slackChId = Variables.slackChId;
                s.slackOn = Variables.slackOn;
                s.slackToken = Variables.slackToken;

                SharedParam.SetParameter(app, doc, Variables.defNameSettings, JsonConvert.SerializeObject(s).ToString());
            }

            return Result.Succeeded;
        }

     }

}