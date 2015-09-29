using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace Slack
{

    public class SlackClient
    {

        private readonly string token;
        private readonly RestClient client;

        public SlackClient(string token)
        {
            this.token = token;
            this.client = new RestClient(Constants.Urls.baseurl);
        }
        
        public IRestResponse<ChannelsListResponse> GetChannelsList(bool excludeArchived)
        {
            var uri = string.Format(Constants.ChannelList.List, this.token, excludeArchived ? 0 : 1);
            var request = new RestRequest(uri, Method.GET);
            IRestResponse<ChannelsListResponse> response = client.Execute<ChannelsListResponse>(request);
            return response;
        }

        public IRestResponse<ChatPostMessageResponse> PostMessage(            
            string text,
            string channel = null,
            string botName = null,
            string parse = null,
            bool linkNames = false,
            Attachments attachments = null,
            bool unfurl_links = false,
            bool unfurl_media = false,
            string icon_url = null,
            string icon_emoji = null)
        {

            //Build Slack WebAPI URL
            var uri = string.Format(Constants.Chat.Post, this.token, channel, text);
            
            if (!string.IsNullOrEmpty(botName)) uri += "&username=" + botName;
            if (!string.IsNullOrEmpty(parse)) uri += "&parse=" + parse;
            if (linkNames) uri += "&link_names=1";
            if (attachments != null) uri += "&attachments=[" + JsonConvert.SerializeObject(attachments) + "]";
            if (unfurl_links) uri += "&unfurl_links=1";
            if (unfurl_media) uri += "&unfurl_media=1";
            if (!string.IsNullOrEmpty(icon_url)) uri += "&icon_url=" + icon_url;
            if (!string.IsNullOrEmpty(icon_emoji)) uri += "&icon_emjoi=" + icon_emoji;

            var request = new RestRequest(uri, Method.POST);
            IRestResponse<ChatPostMessageResponse> response = client.Execute<ChatPostMessageResponse>(request);
            return response;
        }

        public void DeleteMessage(List<string> ts, string channel)
        {
            foreach (string t in ts)
            {
                var uri = string.Format(Constants.Chat.Delete, this.token, t, channel);
                var request = new RestRequest(uri, Method.POST);
                client.Execute(request);

            }
        }

       public void UploadFile(string file, string channel)
        {
            var uri = string.Format(Constants.Files.Upload, this.token, file, channel);
        }
    }
    public class Settings
    {
        public bool slackOn;
        public string slackCh;
        public string slackChId;
        public string slackToken;
    }
}

