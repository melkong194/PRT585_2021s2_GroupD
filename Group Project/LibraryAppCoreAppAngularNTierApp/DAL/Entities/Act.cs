using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Act
    {
        public Int64 ActID { get; set; } //(PK)
        public String Act_Desc { get; set; }
        public String Act_Time { get; set; }
        public String Act_Date { get; set; }
        public Int64 Act_userID { get; set; }
        public String Act_userName { get; set; }
        public String Act_lat { get; set; }
        public String Act_lng { get; set; }
    }
}
