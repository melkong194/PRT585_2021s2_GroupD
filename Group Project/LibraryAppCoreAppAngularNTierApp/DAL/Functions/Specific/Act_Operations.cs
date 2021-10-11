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
    public class Act_Operations : IAct_Operations
    {
        public async Task<Act> Create(Act objectToAdd)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    await context.AddAsync<Act>(objectToAdd);
                    await context.SaveChangesAsync();
                    return objectToAdd;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Act> Read(Int64 entityId)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var result = await context.FindAsync<Act>(entityId);
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Act>> ReadAll()
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var result = await context.Set<Act>().ToListAsync();
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Act> Update(Act objectToUpdate, Int64 entityId)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var objectFound = await context.FindAsync<Act>(entityId);
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
                    var recordToDelete = await context.FindAsync<Act>(entityId);
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
