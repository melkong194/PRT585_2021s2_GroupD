using business.Interfaces;
using business.Models.Admin;
using Data.Entities;
using Data.Functions.Interfaces;
using Data.Functions.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.Implementation
{
    public class Admin_Serv : IAdmin_Serv
    {
        private IAdmin_Ops _admin_ops = new Admin_Ops();
        public async Task<Generic_ResultSet<Admin_ResultSet>> Add(string fname, string lname, string username, string password)
        {
            Generic_ResultSet<Admin_ResultSet> result = new Generic_ResultSet<Admin_ResultSet>();
            try
            {
                Admin Admin = new Admin
                {
                    FirstName = fname,
                    LastName = lname,
                    Username = username
                };

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname))
                {
                    result.success = false;
                    result.userMessage = "Invalid Input";
                    return result;
                }

                Admin = await _admin_ops.Create(Admin, password);

                if (Admin == null)
                {
                    result.success = false;
                    result.userMessage = "Cannot Create";
                    return result;
                }

                Admin_ResultSet adminAdded = new Admin_ResultSet
                {
                    FirstName = Admin.FirstName,
                    LastName = Admin.LastName,
                    Username = Admin.Username,
                    Password = password,
                };


                result.userMessage = string.Format("Added successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Unit_Service: AddUnit() method executed successfully.";
                result.result_set = adminAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Unit Unit supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Unit_Service: AddUnit(): {0}", exception.Message); ;
            }
            return result;
        }

        public async Task<Generic_ResultSet<Admin_ResultSet>> Authenticate(string username, string password)
        {
            Generic_ResultSet<Admin_ResultSet> result = new Generic_ResultSet<Admin_ResultSet>();
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    result.success = false;
                    result.userMessage = "Invalid Input";
                    return result;
                }

                var Admin = await _admin_ops.Authenticate(username, password);

                if (Admin == null)
                {
                    result.success = false;
                    result.userMessage = "Wrong password or Username";
                    return result;
                }

                result.result_set = new Admin_ResultSet
                {
                    Id = Admin.Id,
                    FirstName = Admin.FirstName,
                    LastName = Admin.LastName,
                    Username = Admin.Username,
                    Password = password,
                };


                result.userMessage = string.Format("Login successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Unit_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Unit_Service: AddUnit(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<bool>> Delete(int id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {

                var isDeleted = await _admin_ops.Delete(id);


                result.userMessage = string.Format("deleted successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Unit_Service: DeleteUnit() method executed successfully.";
                result.result_set = isDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Unit Unit supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Unit_Service: DeleteUnit(): {0}", exception.Message); ;
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<Admin_ResultSet>>> GetAll()
        {
            Generic_ResultSet<List<Admin_ResultSet>> result = new Generic_ResultSet<List<Admin_ResultSet>>();
            try
            {
                List<Admin> Admins = await _admin_ops.ReadAll();
                result.result_set = new List<Admin_ResultSet>();
                Admins.ForEach(s =>
                {
                    result.result_set.Add(new Admin_ResultSet
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Username = s.Username,
                        Password = null,
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Unit_Service: GetAllUnits() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Unit Units from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Unit_Service: GetAllUnits(): {0}", exception.Message); ;
            }
            return result;
        }

        public async Task<Generic_ResultSet<Admin_ResultSet>> Read(int id)
        {
            Generic_ResultSet<Admin_ResultSet> result = new Generic_ResultSet<Admin_ResultSet>();
            try
            {

                var Admin = await _admin_ops.Read(id);

                if (Admin == null)
                {
                    result.success = false;
                    result.userMessage = "Cannot found";
                    return result;
                }

                result.result_set = new Admin_ResultSet
                {
                    Id = Admin.Id,
                    FirstName = Admin.FirstName,
                    LastName = Admin.LastName,
                    Username = Admin.Username,
                    Password = null,
                };


                result.userMessage = string.Format("obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Unit_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Unit  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Unit_Service: Get ByID(): {0}", exception.Message); ;
            }
            return result;
        }

        public async Task<Generic_ResultSet<Admin_ResultSet>> Update(int id, string fname, string lname, string username, string password)
        {
            Generic_ResultSet<Admin_ResultSet> result = new Generic_ResultSet<Admin_ResultSet>();
            try
            {
                Admin Admin = new Admin
                {
                    Id = id,
                    FirstName = fname,
                    LastName = lname,
                    Username = username
                };

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname))
                {
                    result.success = false;
                    result.userMessage = "Invalid Input";
                    return result;
                }

                Admin = await _admin_ops.Update(Admin, password);

                if (Admin == null)
                {
                    result.success = false;
                    result.userMessage = "Wrong pass or username";
                    return result;
                }

                Admin_ResultSet adminUpdated = new Admin_ResultSet
                {
                    Id = Admin.Id,
                    FirstName = Admin.FirstName,
                    LastName = Admin.LastName,
                    Username = Admin.Username,
                    Password = password,
                };


                result.userMessage = string.Format("updated successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Unit_Service: UpdateUnit() method executed successfully.";
                result.result_set = adminUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {

                result.exception = exception;
                result.userMessage = "failed. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Unit_Service: UpdateUnit(): {0}", exception.Message); ;
            }
            return result;
        }
    }
}
