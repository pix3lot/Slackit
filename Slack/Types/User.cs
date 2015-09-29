using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slack
{

    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool deleted { get; set; }
        public string color { get; set; }
        public Profile profile { get; set; }
        public bool is_admin { get; set; }
        public bool is_owner { get; set; }
        public bool is_primary_owner { get; set; }
        public bool is_restricted { get; set; }
        public bool is_ultra_restricted { get; set; }
        public bool has_2fa { get; set; }
        public bool has_files { get; set; }
    }

    public class Profile
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string real_name { get; set; }
        public string email { get; set; }
        public string skype { get; set; }
        public string phone { get; set; }
        public string image_24 { get; set; }
        public string image_32 { get; set; }
        public string image_48 { get; set; }
        public string image_72 { get; set; }
        public string image_192 { get; set; }
    }
}

