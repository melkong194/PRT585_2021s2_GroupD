using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IEvent_Operations
    {
        Task<Event> Create(Event objectToAdd);
        Task<Event> Read(Int64 entityId);
        Task<List<Event>> ReadAll();
        Task<Event> Update(Event objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
