using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_API.Models.User
{
    public class User_Pass_Object
    {
        public int id { get; set; }
        public string name { get; set; }
        public string account { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string status { get; set; }
        public string hour { get; set; }
    }
}
