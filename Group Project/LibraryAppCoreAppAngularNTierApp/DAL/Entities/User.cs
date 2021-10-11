using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User
    {
        public Int64 UserID { get; set; } //(PK)
        public String User_Name { get; set; }
        public String User_Account { get; set; }
        public String User_Password { get; set; }
        public String User_Role { get; set; }
        public String User_Status { get; set; }
        public String User_Hour { get; set; }
    }
}
