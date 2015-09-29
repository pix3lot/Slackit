using System;
using Newtonsoft.Json;

namespace Slack
{
    public class ChannelsListResponse: Response
    {
        public Slack.Channels[] channels;
    }

}
