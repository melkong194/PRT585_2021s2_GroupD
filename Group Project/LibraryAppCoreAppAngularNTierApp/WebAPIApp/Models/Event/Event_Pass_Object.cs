using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_API.Models.Event
{
    public class Event_Pass_Object
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string recurrence_rule { get; set; }

    }
}
