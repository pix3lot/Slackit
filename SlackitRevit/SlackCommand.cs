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
using Slack;
using RestSharp;
using Newtonsoft.Json;

#endregion

namespace SlackitRevit
{
    [Transaction(TransactionMode.Manual)]

    public class SlackCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            SlackForm slackForm = new SlackForm();

            slackForm.ShowDialog();

            if (slackForm.DialogResult == DialogResult.OK)
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
                s.giphyOn = Variables.giphyOn;
                s.slackToken = Variables.slackToken;
                //SharedParam.SetParameter(app, doc, Variables.defNameSettings, JsonConvert.SerializeObject(s).ToString());
                SlackitExtStoSettings.SetParameters(app, doc, Variables.defNameSettings, s);
            }
            return Result.Succeeded;
        }
    
    }

}