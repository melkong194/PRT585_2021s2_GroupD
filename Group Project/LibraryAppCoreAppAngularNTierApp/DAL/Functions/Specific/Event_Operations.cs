using DAL.DataContext;
using DAL.Entities;
using DAL.Functions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Specific
{
    public class Event_Operations : IEvent_Operations
    {
        public async Task<Event> Create(Event objectToAdd)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    await context.AddAsync<Event>(objectToAdd);
                    await context.SaveChangesAsync();
                    return objectToAdd;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Event> Read(Int64 entityId)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var result = await context.FindAsync<Event>(entityId);
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Event>> ReadAll()
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var result = await context.Set<Event>().ToListAsync();
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Event> Update(Event objectToUpdate, Int64 entityId)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var objectFound = await context.FindAsync<Event>(entityId);
                    if (objectFound != null)
                    {
                        context.Entry(objectFound).CurrentValues.SetValues(objectToUpdate);
                        await context.SaveChangesAsync();
                    }
                    return objectFound;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(Int64 entityId)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var recordToDelete = await context.FindAsync<Event>(entityId);
                    if (recordToDelete != null)
                    {
                        context.Remove(recordToDelete);
                        await context.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
