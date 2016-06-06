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
        List<string> msgts_synching = new List<string>();
        List<string> msgts_model = new List<string>();
        List<string> msgts_ws = new List<string>();
        List<string> msgts_extra = new List<string>();
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

            #region Variables: Document & Application Variables
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
            Variables.logFileSize = Convert.ToInt32(f.Length / 1000000);

            Variables.logUsername = app.Username;
            Variables.logVersionBuild = app.VersionBuild;
            Variables.logVersionName = app.VersionName;
            Variables.logVersionNumber = app.VersionNumber;
            #endregion

            #region Settings: Load settings if they exist (Extensible Storage)
            ParameterCommands.Load(doc);
            #endregion

            #region Post: Worksharing Warning-Opened Central Model
            bool patheq = string.Equals(Variables.logFileCentral, Variables.logFilePath);

            if (Variables.slackOn && Variables.slackWSWarn)
            {
                if (patheq && Variables.logIsWorkshared)
                {
                    string gif_lg_url = null;
                    string gif_sm_url = null;

                    if (Variables.giphySet > 0)
                    {
                        var giphyClient = new GiphyClient();
                        string gif_msg = giphyClient.GetRandomGif("Alarm").Content;
                        var gif_resp = JsonConvert.DeserializeObject<Giphy.Response>(gif_msg);

                        if (Variables.giphySet == 1)
                        {
                            gif_sm_url = gif_resp.data.fixed_height_small_url;
                        }

                        if (Variables.giphySet == 2)
                        {
                            gif_lg_url = gif_resp.data.image_url;
                        }

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
                        image_url = gif_lg_url,
                        thumb_url = gif_sm_url
                    };

                    string msg_response = slackClient.PostMessage(text, channel: channel, botName: botname, attachments: attachments, icon_url: icon_url).Content;
                    var resp = JsonConvert.DeserializeObject<ChatPostMessageResponse>(msg_response);
                    msgts_ws.Add(resp.ts);
                }
            }
            #endregion

            #region Post: Model Warning-File Size > 300MB
            if (Variables.slackOn && Variables.slackModelWarn)
            {
                string gif_lg_url = null;
                string gif_sm_url = null;

                if (Variables.logFileSize > 300)
                {
                    if (Variables.giphySet > 0)
                    {
                        var giphyClient = new GiphyClient();
                        string gif_msg = giphyClient.GetRandomGif("Gasp").Content;
                        var gif_resp = JsonConvert.DeserializeObject<Giphy.Response>(gif_msg);

                        if (Variables.giphySet == 1)
                        {
                            gif_sm_url = gif_resp.data.fixed_height_small_url;
                        }

                        if (Variables.giphySet == 2)
                        {
                            gif_lg_url = gif_resp.data.image_url;
                        }

                        var slackClient = new SlackClient(Variables.slackToken);

                        string text = "";
                        string channel = Variables.slackChId;
                        string botname = "Model Warning";
                        string icon_url = Variables.icon_revit;

                        var attachments = new Attachments
                        {
                            fallback = "The file size has gone above 300MB, time to do some model file size management.",
                            color = "danger",
                            fields =
                                new Fields[]
                                {
                                    new Fields
                                    {
                                        title = "Description",
                                        value = "The file size is above 300MB, time to do some model maintenance",
                                        @short = false
                                    },
                                    new Fields
                                    {
                                        title = "File Size",
                                        value = Variables.logFileSize.ToString() + "MB",
                                        @short = true
                                    },
                                    new Fields
                                    {
                                        title = "File",
                                        value = Variables.logFileCentralName,
                                        @short = true
                                    }
                                },
                            image_url = gif_lg_url,
                            thumb_url = gif_sm_url
                        };

                        string msg_response = slackClient.PostMessage(text, channel: channel, botName: botname, attachments: attachments, icon_url: icon_url).Content;
                        var resp = JsonConvert.DeserializeObject<ChatPostMessageResponse>(msg_response);

                        msgts_model.Add(resp.ts);
                    }
                }
                #endregion

                #region Tracking: Start Logging Pinned Elements
                IEnumerable<Element> a = TrackChanges.Command.GetTrackedElements(doc);
                _start_state = TrackChanges.Command.GetSnapshot(a);

                #endregion

                #region Post: Tracking-Pinned Element-Started

                if (Variables.slackOn && Variables.slackExtraTrackPin)
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
                    msgts_extra.Add(resp.ts);
                }
                #endregion

            }
        }

        private void appDocSynching(object sender, Autodesk.Revit.DB.Events.DocumentSynchronizingWithCentralEventArgs e)
        {
            Variables.logSyncStart = DateTime.Now;
            Variables.logSyncComments = e.Comments;
            Document doc = e.Document;

            #region Extra: Tracking-Report Differences after Sync
            IEnumerable<Element> a = TrackChanges.Command.GetTrackedElements(doc);
            Dictionary<int, string> end_state = TrackChanges.Command.GetSnapshot(a);
            var first = end_state.First();
            string results = TrackChanges.Command.ReportDifferences(doc, _start_state, end_state);
            _start_state = TrackChanges.Command.GetSnapshot(a);
            Fields trackPinSomething = new Fields
            {
                title = "Pinned Elements",
                value = results,
                @short = true
            };

            #endregion

            #region Post: Worksharing Info-Synchronizing to Central

            if (Variables.slackOn && Variables.slackWSWarn)
            {
                var slackClient = new SlackClient(Variables.slackToken);
                if (!Variables.slackExtraTrackPin)
                {
                    trackPinSomething = null;
                }

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
                            trackPinSomething
                        }
                };

                string msg_response = slackClient.PostMessage(text, channel: channel, botName: botname, attachments: attachments, icon_url: icon_url).Content;
                var resp = JsonConvert.DeserializeObject<ChatPostMessageResponse>(msg_response);
                msgts_synching.Add(resp.ts);

            }
            #endregion
        }

        private void appDocSynched(object sender, Autodesk.Revit.DB.Events.DocumentSynchronizedWithCentralEventArgs e)
        {

            Variables.logSyncEnd = DateTime.Now;
            Variables.logSyncDuration = Variables.logSyncEnd - Variables.logSyncStart;
            Document doc = e.Document;

            #region Settings: Reload from Extensible Storage
            ParameterCommands.Load(doc);
            #endregion

            #region Extra: Tracking-Report Differences after Sync
            IEnumerable<Element> a = TrackChanges.Command.GetTrackedElements(doc);
            Dictionary<int, string> end_state = TrackChanges.Command.GetSnapshot(a);
            var first = end_state.First();
            string results = TrackChanges.Command.ReportDifferences(doc, _start_state, end_state);
            _start_state = TrackChanges.Command.GetSnapshot(a);

            #endregion

            #region Post: Worksharing Info-Synchronized to Central

            if (Variables.slackOn && Variables.slackWSInfo)
            {
                string gif_lg_url = null;
                string gif_sm_url = null;

                if (Variables.giphySet > 0)
                {
                    var giphyClient = new GiphyClient();
                    string gif_msg = giphyClient.GetRandomGif("ThumbsUp").Content;
                    var gif_resp = JsonConvert.DeserializeObject<Giphy.Response>(gif_msg);

                    if (Variables.giphySet == 1)
                    {
                        gif_sm_url = gif_resp.data.fixed_height_small_url;
                    }
                    if (Variables.giphySet == 2)
                    {
                        gif_lg_url = gif_resp.data.image_url;
                    }

                }
                var slackClient = new SlackClient(Variables.slackToken);

                //Delete previous synching message, if enabled
                if (Variables.tidySet > 0)
                {
                    slackClient.DeleteMessage(msgts_synching, Variables.slackChId);
                    msgts_synching.Clear();
                }

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
                                value = Variables.logUsername + " has synched to central.\n[" + Variables.logFileCentralName + " (Size: "+ Variables.logFileSize.ToString() + "MB) ]",
                                @short = true
                            },
                            new Fields
                            {
                                title = "Duration",
                                value = string.Format("{0:hh\\:mm\\:ss}", Variables.logSyncDuration),
                                @short = true
                            }
                        },
                    image_url = gif_lg_url,
                    thumb_url = gif_sm_url

                };

                string msg_response = slackClient.PostMessage(text, channel: channel, botName: botname, attachments: attachments, icon_url: icon_url).Content;
                var resp = JsonConvert.DeserializeObject<ChatPostMessageResponse>(msg_response);
                msgts_synching.Add(resp.ts);
            }
            #endregion

        }


        private void appDocClosing(object sender, Autodesk.Revit.DB.Events.DocumentClosingEventArgs e)
        {

            BasicFileInfo fileInfo = BasicFileInfo.Extract(Variables.logFilePath);

            #region Post: Worksharing Warning-Close without saving

            if (Variables.slackOn && Variables.slackWSWarn)
            {
                if (fileInfo.AllLocalChangesSavedToCentral == false)
                {
                    string gif_lg_url = null;
                    string gif_sm_url = null;

                    if (Variables.giphySet > 0)
                    {
                        var giphyClient = new GiphyClient();
                        string gif_msg = giphyClient.GetRandomGif("Disappointed").Content;
                        var gif_resp = JsonConvert.DeserializeObject<Giphy.Response>(gif_msg);
                        if (Variables.giphySet == 1)
                        {
                            gif_sm_url = gif_resp.data.fixed_height_small_url;
                        }
                        if (Variables.giphySet == 2)
                        {
                            gif_lg_url = gif_resp.data.image_url;
                        }

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
                        image_url = gif_lg_url,
                        thumb_url = gif_sm_url
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
}