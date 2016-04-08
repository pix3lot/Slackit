using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slack
{
    public static class Constants
    {
        public class Urls
        {
            public static string baseurl = "https://slack.com/api/";
        }

        internal class Users
        {
            internal const string List = "users.list?token={0}";
        }

        internal class ChannelList
        {
            internal const string List = "channels.list?token={0}&exclude_archived={1}";
        }

        internal class Chat
        {
            internal const string Post = "chat.postMessage?token={0}&channel={1}&text={2}";
            internal const string Delete = "chat.delete?token={0}&ts={1}&channel={2}";
        }
        internal class Files
        {
            internal const string Upload = "files.upload?token={0}&channels={1}";
        }
    }

}
