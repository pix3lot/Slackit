using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slack
{
    public class ChatPostMessageResponse
    {
            public bool ok { get; set; }
            public string ts { get; set; }
            public string channel { get; set; }
            public Message message { get; set; }
    }

    public class Message
        {
            public string text { get; set; }
            public string username { get; set; }
            public string type { get; set; }
            public string subtype { get; set; }
            public string ts { get; set; }
        }
    }

