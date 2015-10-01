using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Newtonsoft.Json;
using Slack;

namespace SlackitRevit
{
    public class EventHandler : IExternalEventHandler
    {

        /// <summary>
        ///   A method to identify this External Event Handler
        /// </summary>
        public String GetName()
        {
            return "Get Slack Channel List";
        }

        /// <summary>
        ///   The top function that distributes requests to individual methods. 
        /// </summary>
        public void Execute(UIApplication uiapp)
        {
            try
            {
                GetChannels(uiapp);
            }
                
            
            catch (Exception e)
            {
                TaskDialog.Show("Get Slack Channels", "Exception: " + e );
            }
        }

        
        public void GetChannels(UIApplication uiapp)
        {
            var slackClient = new SlackClient(Variables.slackToken);

            string ch_response = slackClient.GetChannelsList(true).Content;

            var ch = JsonConvert.DeserializeObject<ChannelsListResponse>(ch_response);

            foreach (var item in ch.channels)
            {
                Variables.slackChannelNameId.Add(item.name, item.id);
            }

            foreach (var item in ch.channels)
            {
                Variables.slackChannelName.Add(item.name);
            }
        }
    }
}
