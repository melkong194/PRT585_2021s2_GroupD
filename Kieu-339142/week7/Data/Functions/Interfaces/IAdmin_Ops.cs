using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Functions.Interfaces
{
    public interface IAdmin_Ops
    {
        Task<Admin> Authenticate(string username, string password);
        Task<Admin> Create(Admin user, string password);
        Task<Admin> Update(Admin user, string password = null);
        Task<bool> Delete(int id);
        Task<Admin> Read(int id);
        Task<List<Admin>> ReadAll();
    }
}
