using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface ICourse_Operations
    {
        Task<Course> Create(Course objectToAdd);
        Task<Course> Read(Int64 entityId);
        Task<List<Course>> ReadAll();
        Task<Course> Update(Course objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
