using business.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.Interfaces
{
    public interface IAdmin_Serv
    {
        Task<Generic_ResultSet<Admin_ResultSet>> Authenticate(string username, string password);
        Task<Generic_ResultSet<Admin_ResultSet>> Add(string fname, string lname, string username, string password);
        Task<Generic_ResultSet<List<Admin_ResultSet>>> GetAll();
        Task<Generic_ResultSet<Admin_ResultSet>> Read(int id);
        Task<Generic_ResultSet<Admin_ResultSet>> Update(int id, string fname, string lname, string username, string password);
        Task<Generic_ResultSet<bool>> Delete(int id);
    }
}
