using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slack
{
    public class Group
    {
        public string id { get; set; }
        public string name { get; set; }
        public string is_group { get; set; }
        public int created { get; set; }
        public string creator { get; set; }
        public bool is_archived { get; set; }
        public List<string> members { get; set; }
        public Topic topic { get; set; }
        public Purpose purpose { get; set; }
    }

    //public class Topic
    //{
    //    public string value { get; set; }
    //    public string creator { get; set; }
    //    public int last_set { get; set; }
    //}

    //public class Purpose
    //{
    //    public string value { get; set; }
    //    public string creator { get; set; }
    //    public int last_set { get; set; }
    //}


}
