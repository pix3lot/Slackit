using System;
using System.IO;
using System.Collections.Generic;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Giphy;
using Slack;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SlackitRevit
{
    [Transaction(TransactionMode.Automatic)]

    public class EventsApplication : IExternalApplication
    {

        List<string> msgts_synch = new List<string>();
        List<string> msgts_model = new List<string>();
        List<string> msgts_ws = new List<string>();
        Dictionary<int, string> _start_state = null;

        public Result OnStartup(UIControlledApplication uicapp)
        {
            //Register Events for Logging
            uicapp.ControlledApplication.DocumentOpening += new EventHandler<Autodesk.Revit.DB.Events.DocumentOpeningEventArgs>(appDocOpening);
            uicapp.ControlledApplication.DocumentOpened += new EventHandler<Autodesk.Revit.DB.Events.DocumentOpenedEventArgs>(appDocOpened);
            uicapp.ControlledApplication.DocumentSynchronizingWithCentral += new EventHandler<Autodesk.Revit.DB.Events.DocumentSynchronizingWithCentralEventArgs>(appDocSynching);
            uicapp.ControlledApplication.DocumentSynchronizedWithCentral += new EventHandler<Autodesk.Revit.DB.Events.DocumentSynchronizedWithCentralEventArgs>(appDocSynched);
            uicapp.ControlledApplication.DocumentClosing += new EventHandler<Autodesk.Revit.DB.Events.DocumentClosingEventArgs>(appDocClosing);


            return Result.Succeeded;
        }

        private void appDocOpening(object sender, Autodesk.Revit.DB.Events.DocumentOpeningEventArgs e)
        {
            Variables.logOpenStart = DateTime.Now;
        }

        private void appDocOpened(object sender, Autodesk.Revit.DB.Events.DocumentOpenedEventArgs e)
        {
            Variables.logOpenEnd = DateTime.Now;
            Variables.logOpenDuration = Variables.logOpenEnd - Variables.logOpenStart;

            Autodesk.Revit.ApplicationServices.Application app = sender as Autodesk.Revit.ApplicationServices.Application;
            Document doc = e.Document;

            #region Log document & application variables
            string path = doc.PathName;

            BasicFileInfo fileInfo = BasicFileInfo.Extract(path);
            FileInfo f = new FileInfo(path);
            
            Variables.logComputerName = Environment.MachineName;
            Variables.logChangesSaved = fileInfo.AllLocalChangesSavedToCentral;
            Variables.logFileCentral = fileInfo.CentralPath;
            Variables.logFileCentralName = Path.GetFileName(Variables.logFileCentral);
            Variables.logIsCentral = fileInfo.IsCentral;
            Variables.logIsWorkshared = fileInfo.IsWorkshared;
            Variables.logCreatedLocal = fileInfo.IsCreatedLocal;

            Variables.logFileName = doc.Title;
            Variables.logFilePath = doc.PathName;
            Variables.logFileSize = f.Length;

            Variables.logUsername = app.Username;
            Variables.logVersionBuild = app.VersionBuild;
            Variables.logVersionName = app.VersionName;
            Variables.logVersionNumber = app.VersionNumber;
            #endregion


            #region Load settings if they exist (Extensible Storage)
            ParameterCommands.Load(doc);
            #endregion

            #region Slack Post: Opened central model
            bool patheq = string.Equals(Variables.logFileCentral, Variables.logFilePath);

            if (Variables.slackOn)
            {


                if (patheq && Variables.logIsWorkshared)
                {
                    string gif_url = null;
                    if (Variables.giphyOn)
                    {
                        var giphyClient = new GiphyClient();
                        string gif_msg = giphyClient.GetRandomGif("Alarm").Content;
                        var gif_resp = JsonConvert.DeserializeObject<Giphy.Response>(gif_msg);
                        gif_url = gif_resp.data.image_url;
                    }

                    var slackClient = new SlackClient(Variables.slackToken);

                    string text = "";
                    string channel = Variables.slackChId;
                    string botname = "Worksharing Warning";
                    string icon_url = Variables.icon_revit;

                    var attachments = new Attachments
                    {
                        fallback = Variables.logUsername + "has opened the central model",
                        color = "danger",
                        fields =
                            new Fields[]
                            {
                                new Fields
                                {
                                    title = "Description",
                                    value = "The user has opened the central model. Close the central model and create a new local file> to work from.",
                                    @short = false
                                },
                                new Fields
                                {
                                    title = "User",
                                    value = Variables.logUsername,
                                    @short = true
                                },
                                new Fields
                                {
                                    title = "File",
                                    value = Variables.logFileCentralName,
                                    @short = true
                                }
                            },
                            image_url = gif_url
                      

                    };
                    
                    string msg_response = slackClient.PostMessage(text, channel: channel, botName: botname, attachments: attachments, icon_url: icon_url).Content;
                    var resp = JsonConvert.DeserializeObject<ChatPostMessageResponse>(msg_response);
                    msgts_ws.Add(resp.ts);
                }
            }
            #endregion

            #region Start Logging Pinned Elements
            IEnumerable<Element> a = TrackChanges.Command.GetTrackedElements(doc);
            _start_state = TrackChanges.Command.GetSnapshot(a);

            #endregion

            #region Slack Post: Pinned Tracking Started

            if (Variables.slackOn)
            {

                var slackClient = new SlackClient(Variables.slackToken);
                                
                //Post pinned elements message
                string text = "";
                string channel = Variables.slackChId;
                string botname = "Pinning Info";
                string icon_url = Variables.icon_revit;
  

                var attachments = new Attachments
                {
                    fallback = Variables.logUsername + "has started tracking pinned elements.",
                    color = "good",
                    fields =
                        new Fields[]
                        {
                            new Fields
                            {
                                title = "Status",
                                value = Variables.logUsername + " has started tracking pinned elements.\n[" + Variables.logFileCentralName + "]",
                                @short = true
                            }
                        }
                };

                string msg_response = slackClient.PostMessage(text, channel: channel, botName: botname, attachments: attachments, icon_url: icon_url).Content;
                var resp = JsonConvert.DeserializeObject<ChatPostMessageResponse>(msg_response);


            }
            #endregion

        }

        private void appDocSynching(object sender, Autodesk.Revit.DB.Events.DocumentSynchronizingWithCentralEventArgs e)
        {
            Variables.logSyncStart = DateTime.Now;
            Variables.logSyncComments = e.Comments;
            Document doc = e.Document;

            #region Report Differences after Sync
            IEnumerable<Element> a = TrackChanges.Command.GetTrackedElements(doc);
            Dictionary<int, string> end_state = TrackChanges.Command.GetSnapshot(a);
            var first = end_state.First();
            string results = TrackChanges.Command.ReportDifferences(doc, _start_state, end_state);
            _start_state = TrackChanges.Command.GetSnapshot(a);
            #endregion

            #region Slack Post: Synchronizing to Central

            if (Variables.slackOn)
            {
                var slackClient = new SlackClient(Variables.slackToken);

                string text = "";
                string channel = Variables.slackChId;
                string botname = "Synching Info";
                string icon_url = Variables.icon_revit;

                var attachments = new Attachments
                {
                    fallback = Variables.logUsername + " is synching",
                    color = "warning",
                    fields =
                        new Fields[]
                        {
                            new Fields
                            {
                                title = "Status",
                                value = Variables.logUsername + " is synching to central [" + Variables.logFileCentralName + "]\nAvoid synching until this is complete.",
                                @short = true
                            },
                            new Fields
                            {
                                title = "Pinned Elements",
                                value = results,
                                @short = true
                            }
                        }
                };

                string msg_response = slackClient.PostMessage(text, channel: channel, botName: botname, attachments: attachments, icon_url: icon_url).Content;
                var resp = JsonConvert.DeserializeObject<ChatPostMessageResponse>(msg_response);

                msgts_synch.Add(resp.ts);
            }
            #endregion
        }

        private void appDocSynched(object sender, Autodesk.Revit.DB.Events.DocumentSynchronizedWithCentralEventArgs e)
        {
            
            Variables.logSyncEnd = DateTime.Now;
            Variables.logSyncDuration = Variables.logSyncEnd - Variables.logSyncStart;
            Document doc = e.Document;

            string path = doc.PathName;
            BasicFileInfo fileInfo = BasicFileInfo.Extract(path);

            FileInfo f = new FileInfo(fileInfo.CentralPath);
            string size = Convert.ToInt32(f.Length / 1000000).ToString();
            string folder = f.DirectoryName;
            var csv = new StringBuilder();
            var date = DateTime.Now.ToString();
            var newLine = string.Format("{0},{1}", date, size);
            csv.AppendLine(newLine);
            string logPath = folder + "\\fileSizelog.csv";
            File.AppendAllText(logPath, csv.ToString());

            #region Reload settings from Extensible Storage
            ParameterCommands.Load(doc);
            #endregion


            #region Report Differences after Sync
            IEnumerable<Element> a = TrackChanges.Command.GetTrackedElements(doc);
            Dictionary<int, string> end_state = TrackChanges.Command.GetSnapshot(a);
            var first = end_state.First();
            string results = TrackChanges.Command.ReportDifferences(doc, _start_state, end_state);
            _start_state = TrackChanges.Command.GetSnapshot(a);

            #endregion

            #region Slack Post: Synchronized to Central

            if (Variables.slackOn)
            {
                string gif_url = null;
                if (Variables.giphyOn)
                {
                    var giphyClient = new GiphyClient();
                    string gif_msg = giphyClient.GetRandomGif("ThumbsUp").Content;
                    var gif_resp = JsonConvert.DeserializeObject<Giphy.Response>(gif_msg);
                    gif_url = gif_resp.data.image_url;
                }
                var slackClient = new SlackClient(Variables.slackToken);

                //Delete previous synching message
                slackClient.DeleteMessage(msgts_synch, Variables.slackCh);
                msgts_synch.Clear();

                //Post synched message
                string text = "";
                string channel = Variables.slackChId;
                string botname = "Synching Info";
                string icon_url = Variables.icon_revit;

                var attachments = new Attachments
                {
                    fallback = Variables.logUsername + "has synched",
                    color = "good",
                    fields =
                        new Fields[]
                        {
                            new Fields
                            {
                                title = "Status",
                                value = Variables.logUsername + " has synched to central.\n[" + Variables.logFileCentralName + " (Size: "+ size + "MB) ]",
                                @short = true
                            },
                            new Fields
                            {
                                title = "Duration",
                                value = string.Format("{0:hh\\:mm\\:ss}", Variables.logSyncDuration),
                                @short = true
                            }
                        },
                    image_url = gif_url

                };
                
                string msg_response = slackClient.PostMessage(text, channel: channel, botName: botname, attachments: attachments, icon_url: icon_url).Content;
                var resp = JsonConvert.DeserializeObject<ChatPostMessageResponse>(msg_response);
                //File size chart
                Charting.Program.Main(logPath);
                string upload_response = slackClient.UploadFile(@"C:\Temp\chart.png", channel).Content;
                var uploadresp = JsonConvert.DeserializeObject<UploadResponse>(upload_response);

            }
            #endregion


        }
       

        private void appDocClosing(object sender, Autodesk.Revit.DB.Events.DocumentClosingEventArgs e)
        {
            Autodesk.Revit.ApplicationServices.Application app = sender as Autodesk.Revit.ApplicationServices.Application;
            Document doc = e.Document;

            string path = doc.PathName;

            BasicFileInfo fileInfo = BasicFileInfo.Extract(path);
            FileInfo f = new FileInfo(path);

            #region Slack Post: Close without saving

            if (Variables.slackOn)
            {
                if (fileInfo.AllLocalChangesSavedToCentral == false)
                {
                    string gif_url = null;
                    if (Variables.giphyOn)
                    {
                        var giphyClient = new GiphyClient();
                        string gif_msg = giphyClient.GetRandomGif("Disappointed").Content;
                        var gif_resp = JsonConvert.DeserializeObject<Giphy.Response>(gif_msg);
                        gif_url = gif_resp.data.image_url;
                    }
                    var slackClient = new SlackClient(Variables.slackToken);

                    string text = "";
                    string channel = Variables.slackChId;
                    string botname = "Worksharing Warning";
                    string icon_url = Variables.icon_revit;
                    
                    var attachments = new Attachments
                    {
                        fallback = Variables.logUsername + "did not save to central before closing",
                        color = "danger",
                        fields =
                            new Fields[]
                            {                                
                                new Fields
                                {
                                    title = "Description",
                                    value = "The user has closed the model without saving their changes back to the central model. Open the model and save changes back to the central model.",
                                    @short = false
                                },
                                new Fields
                                {
                                    title = "User",
                                    value = Variables.logUsername,
                                    @short = true
                                },
                                new Fields
                                {
                                    title = "File",
                                    value = Variables.logFileCentralName,
                                    @short = true
                                }
                            },
                        image_url = gif_url
                    };
                    
                    string msg_response = slackClient.PostMessage(text, channel: channel, botName: botname, attachments: attachments, icon_url: icon_url).Content;
                    var resp = JsonConvert.DeserializeObject<ChatPostMessageResponse>(msg_response);
                    msgts_ws.Add(resp.ts);
                    
                }
            }
            #endregion
        }

        public Result OnShutdown(UIControlledApplication uicapp)
        {
            uicapp.ControlledApplication.DocumentOpening -= new EventHandler<Autodesk.Revit.DB.Events.DocumentOpeningEventArgs>(appDocOpening);
            uicapp.ControlledApplication.DocumentOpened -= new EventHandler<Autodesk.Revit.DB.Events.DocumentOpenedEventArgs>(appDocOpened);
            uicapp.ControlledApplication.DocumentSynchronizingWithCentral -= new EventHandler<Autodesk.Revit.DB.Events.DocumentSynchronizingWithCentralEventArgs>(appDocSynching);
            uicapp.ControlledApplication.DocumentSynchronizedWithCentral -= new EventHandler<Autodesk.Revit.DB.Events.DocumentSynchronizedWithCentralEventArgs>(appDocSynched);
            uicapp.ControlledApplication.DocumentClosing -= new EventHandler<Autodesk.Revit.DB.Events.DocumentClosingEventArgs>(appDocClosing);

            return Result.Succeeded;
        }

    }
            public static class Collectors
        {
            public static Element GetProjectInfoElem(Document doc)
            {
                FilteredElementCollector col = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_ProjectInformation);
                Element e = col.FirstElement();
                return e;
            }
        }
}
