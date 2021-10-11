using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IAct_Operations
    {
        Task<Act> Create(Act objectToAdd);
        Task<Act> Read(Int64 entityId);
        Task<List<Act>> ReadAll();
        Task<Act> Update(Act objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
