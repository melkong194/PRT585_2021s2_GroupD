using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_API.Models.Act
{
    public class Act_Pass_Object
    {
        public int id { get; set; }
        public string desc { get; set; }
        public string time { get; set; }
        public string date { get; set; }
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }

    }
}
