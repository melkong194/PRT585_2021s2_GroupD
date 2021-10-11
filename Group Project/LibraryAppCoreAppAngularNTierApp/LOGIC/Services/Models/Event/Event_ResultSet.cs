using System;

namespace LOGIC.Services.Models.Event
{
    public class Event_ResultSet
    {
        public Int64 event_id { get; set; }
        public Int64 user_id { get; set; }
        public String user_name { get; set; }
        public String title { get; set; }
        public String start { get; set; }
        public String end { get; set; }
        public String recurrence_rule { get; set; }
    }
}