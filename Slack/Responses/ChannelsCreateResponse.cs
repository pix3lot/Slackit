using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slack
{
    public class ChannelsCreateResponse : Response
    {
        public Slack.Channels[] channels;
    }
}
