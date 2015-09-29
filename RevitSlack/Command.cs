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
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.ExtensibleStorage;
using RestSharp;
using Newtonsoft.Json;
using RevitEvents;
using Slack;

#endregion

namespace RevitSlack
{
    [Transaction(TransactionMode.Manual)]

    public class Command : IExternalCommand
    {
        public static List<string> chlist { get; set; }
        public static Dictionary<string, string> chdict { get; set; }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            #region Get List of Channels Name and ID from Slack


            try
            {
                var ch_name = new List<string>();
                var ch_name_id = new Dictionary<string, string>();
                var slackClient = new SlackClient(Variables.slackToken);
                string ch_response = slackClient.GetChannelsList(true).Content;

                var ch = JsonConvert.DeserializeObject<ChannelsListResponse>(ch_response);

                foreach (var item in ch.channels)
                {
                    ch_name_id.Add(item.name, item.id);
                }

                foreach (var item in ch.channels)
                {
                    ch_name.Add(item.name);
                }

                chdict = ch_name_id;
                chlist = ch_name;
            }
            catch
            {

            }

            #endregion
            
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

                Slack.Settings s = new Slack.Settings();
                s.slackCh = Variables.slackCh;
                s.slackChId = Variables.slackChId;
                s.slackOn = Variables.slackOn;
                //s.slackToken = Variables.slackToken;

                SharedParam.SetParameter(app, doc, Variables.defNameSettings, JsonConvert.SerializeObject(s).ToString());
            }

            return Result.Succeeded;
        }

    }
}