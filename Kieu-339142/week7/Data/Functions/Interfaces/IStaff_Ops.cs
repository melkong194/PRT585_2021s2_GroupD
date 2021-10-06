using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Functions.Interfaces
{
    public interface IStaff_Ops
    {
        Task<Staff> Authenticate(string username, string password);
        Task<Staff> Create(Staff user, string password);
        Task<List<Staff>> ReadAll();
        Task<Staff> Update(Staff user, string password = null);
        Task<Staff> Read(int id);

        Task<bool> Delete(int id);
        Task<List<Staff>> GetStaffsByAdmin(int adminId);
    }
}
