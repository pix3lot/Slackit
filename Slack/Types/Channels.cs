using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Slack
{
    public class Channels
    {
            public string id { get; set; }
            public string name { get; set; }
            public bool is_channel { get; set; }
            public int created { get; set; }
            public bool is_archives { get; set; }
            public bool is_general { get; set; }
            public bool is_member { get; set; }
            public List<string> members { get; set; }
            public Topic Topic { get; set; }
            public Purpose Purpose { get; set; }
            public int num_numbers { get; set; }
    }
}

