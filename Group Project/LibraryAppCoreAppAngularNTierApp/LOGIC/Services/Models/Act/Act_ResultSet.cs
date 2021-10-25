using System;

namespace LOGIC.Services.Models.Act
{
    public class Act_ResultSet
    {
        public Int64 act_id { get; set; }
        public String desc { get; set; }
        public String time { get; set; }
        public String date { get; set; }
        public Int64 user_id { get; set; }
        public String user_name { get; set; }
        public String lat { get; set; }
        public String lng { get; set; }

    }
}