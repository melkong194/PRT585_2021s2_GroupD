using business.Models.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.Interfaces
{
    public interface IStaff_Serv
    {
        Task<Generic_ResultSet<Staff_ResultSet>> Authenticate(string username, string password);
        Task<Generic_ResultSet<Staff_ResultSet>> Add(string fname, string lname, string username, string password, int adminId);
        Task<Generic_ResultSet<List<Staff_ResultSet>>> GetAll();
        Task<Generic_ResultSet<List<Staff_ResultSet>>> GetStaffsByAdmin(int adminId);
        Task<Generic_ResultSet<Staff_ResultSet>> Read(int id);
        Task<Generic_ResultSet<Staff_ResultSet>> Update(int id, string fname, string lname, string username, string password);
        Task<Generic_ResultSet<bool>> Delete(int id);
    }
}
