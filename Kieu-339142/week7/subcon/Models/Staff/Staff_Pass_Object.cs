using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace subcon.Models.Staff
{
    public class Staff_Pass_Object
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int AdminId { get; set; }
    }
}
