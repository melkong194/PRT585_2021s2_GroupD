using Data.DataContext;
using Data.Entities;
using Data.Functions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Functions.Specific
{
    public class Staff_Ops : IStaff_Ops
    {
        public async Task<Staff> Authenticate(string username, string password)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {

                    var user = await context.Staffs.SingleOrDefaultAsync(x => x.Username == username);

                    // check if username exists
                    if (user == null)
                        return null;

                    if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                        return null;

                    return user;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Staff> Create(Staff user, string password)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var resultUser = await context.Staffs.AnyAsync(x => x.Username == user.Username);
                    if (resultUser)
                        return null;

                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash(password, out passwordHash, out passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;

                    await context.AddAsync<Staff>(user);
                    await context.SaveChangesAsync();
                    return user;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var recordToDelete = await context.FindAsync<Staff>(id);
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

        public async Task<Staff> Read(int id)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    return await context.FindAsync<Staff>(id);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Staff>> GetStaffsByAdmin(int adminId)
        {

            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    List<Staff> staffs = await context.Staffs.OrderBy(a => a.FirstName).Where(a => a.AdminId == adminId).ToListAsync();

                    return staffs;
                }
            }
            catch
            {
                throw;
            }

           
        }

        public async Task<List<Staff>> ReadAll()
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var result = await context.Set<Staff>().ToListAsync();
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Staff> Update(Staff newUser, string password = null)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var user = await context.FindAsync<Staff>(newUser.Id);

                    if (user == null)
                        return null;

                    if (newUser.Username != user.Username)
                    {
                        //username has changed so check if the new username is already taken
                        if (context.Staffs.Any(x => x.Username == newUser.Username))
                            return null;
                    }

                    // update user properties
                    user.FirstName = newUser.FirstName;
                    user.LastName = newUser.LastName;
                    user.Username = newUser.Username;

                    // update password if it was entered
                    if (!string.IsNullOrWhiteSpace(password))
                    {
                        byte[] passwordHash, passwordSalt;
                        CreatePasswordHash(password, out passwordHash, out passwordSalt);

                        user.PasswordHash = passwordHash;
                        user.PasswordSalt = passwordSalt;
                    }

                    context.Entry(user).CurrentValues.SetValues(newUser);
                    await context.SaveChangesAsync();
                    return user;
                }
            }
            catch
            {
                throw;
            }
        }
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
