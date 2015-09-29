#region Namespaces

using System;
using System.Net;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

#endregion

namespace Slack
{

    public class SlackClient
    {
        private RestClient _restClient;
        private Uri _webhookUri;

        private const string VALID_HOST = "hooks.slack.com";
        private const string POST_SUCCESS = "ok";

        public SlackClient(string webhookUrl)
        {

            if (!Uri.TryCreate(webhookUrl, UriKind.Absolute, out _webhookUri))
                throw new ArgumentException("Please enter a valid Slack webhook url");

            if (_webhookUri.Host != VALID_HOST)
                throw new ArgumentException("Please enter a valid Slack webhook url");

            var baseUrl = _webhookUri.GetLeftPart(UriPartial.Authority);

            _restClient = new RestClient(baseUrl);

        }

        public bool Post(SlackMessage slackMessage)
        {
            var json_set = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new  CamelCasePropertyNamesContractResolver()
            };

            var request = new RestRequest(_webhookUri.PathAndQuery, Method.POST);

            var json = JsonConvert.SerializeObject(slackMessage, Formatting.None, json_set);

            request.AddParameter("payload", json);

            try
            {
                var response = _restClient.Execute(request);
                return response.StatusCode == HttpStatusCode.OK && response.Content == POST_SUCCESS;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //public void PostMessage(Slack.ChatPostMessage message)
        ////    Action<ChatPostMessageResponse> callback,
        ////    string channelId,
        ////    string text,
        ////    string username = null,
        ////    //bool as_user = false,
        ////    string parse = null,
        ////    bool link_names = false,
        ////    Attachments[] attachments = null,
        ////    bool unfurl_links = false,
        ////    //bool unfurl_media = false,
        ////    string icon_url = null,
        ////    string icon_emoji = null)
        //{
        //    List<Tuple<string, string>> parameters = new List<Tuple<string, string>>();

        //    parameters.Add(new Tuple<string, string>("channel", channelId));
        //    parameters.Add(new Tuple<string, string>("text", text));

        //    if (!string.IsNullOrEmpty(username))
        //        parameters.Add(new Tuple<string, string>("username", username));

        //    if (!string.IsNullOrEmpty(parse))
        //        parameters.Add(new Tuple<string, string>("parse", parse));

        //    if (link_names)
        //        parameters.Add(new Tuple<string, string>("link_names", "1"));

        //    if (attachments != null && attachments.Length > 0)
        //        parameters.Add(new Tuple<string, string>("attachments", JsonConvert.SerializeObject(attachments)));

        //    if (unfurl_links)
        //        parameters.Add(new Tuple<string, string>("unfurl_links", "1"));

        //    if (!string.IsNullOrEmpty(icon_url))
        //        parameters.Add(new Tuple<string, string>("icon_url", icon_url));

        //    if (!string.IsNullOrEmpty(icon_emoji))
        //        parameters.Add(new Tuple<string, string>("icon_emoji", icon_emoji));

        //    //APIRequestWithToken(callback, parameters.ToArray());
        //}

    }
}