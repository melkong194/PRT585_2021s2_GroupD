using System;

namespace LOGIC.Services.Models.User
{
    public class User_ResultSet
    {
        public Int64 user_id { get; set; }
        public String name { get; set; }
        public String account { get; set; }
        public String password { get; set; }
        public String role { get; set; }
        public String status { get; set; }
        public String hour { get; set; }

    }
}