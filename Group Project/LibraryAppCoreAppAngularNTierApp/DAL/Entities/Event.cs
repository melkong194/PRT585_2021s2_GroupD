using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Event
    {
        public Int64 EventID { get; set; } //(PK)
        public Int64 Event_userID { get; set; }
        public String Event_userName { get; set; }
        public String Event_Title { get; set; }
        public String Event_Start { get; set; }
        public String Event_End { get; set; }
        public String Event_RecurrenceRule { get; set; }
    }
}
