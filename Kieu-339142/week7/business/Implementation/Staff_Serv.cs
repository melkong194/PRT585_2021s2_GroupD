using business.Interfaces;
using business.Models.Staff;
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
    public class Staff_Serv : IStaff_Serv
    {
        private IStaff_Ops _staff_ops = new Staff_Ops();
        public async Task<Generic_ResultSet<Staff_ResultSet>> Add(string fname, string lname, string username, string password, int adminId)
        {
            Generic_ResultSet<Staff_ResultSet> result = new Generic_ResultSet<Staff_ResultSet>();
            try
            {
                
                Staff Staff = new Staff
                {
                    FirstName = fname,
                    LastName = lname,
                    Username = username,
                    AdminId = adminId,
                };

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname) || string.IsNullOrEmpty(adminId.ToString()))
                {
                    result.success = false;
                    result.userMessage = "Invalid Input";
                    return result;
                }

                Staff = await _staff_ops.Create(Staff, password);

                if (Staff == null)
                {
                    result.success = false;
                    result.userMessage = "Cannot Create!";
                    return result;
                }

                Staff_ResultSet staffAdded = new Staff_ResultSet
                {
                    FirstName = Staff.FirstName,
                    LastName = Staff.LastName,
                    Username = Staff.Username,
                    Password = password,
                    AdminId = Staff.AdminId,
                };


                result.userMessage = string.Format("Added successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Unit_Service: AddUnit() method executed successfully.";
                result.result_set = staffAdded;
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

        public async Task<Generic_ResultSet<Staff_ResultSet>> Authenticate(string username, string password)
        {
            Generic_ResultSet<Staff_ResultSet> result = new Generic_ResultSet<Staff_ResultSet>();
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    result.success = false;
                    result.userMessage = "Invalid Input";
                    return result;
                }

                var Staff = await _staff_ops.Authenticate(username, password);

                if (Staff == null)
                {
                    result.success = false;
                    result.userMessage = "Wrong password or Username";
                    return result;
                }

                result.result_set = new Staff_ResultSet
                {
                    Id = Staff.Id,
                    FirstName = Staff.FirstName,
                    LastName = Staff.LastName,
                    Username = Staff.Username,
                    Password = password,
                    AdminId = Staff.AdminId
                };


                result.userMessage = string.Format("Login successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Unit_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Unit_Service: AddUnit(): {0}", exception.Message); ;
            }
            return result;
        }

        public async Task<Generic_ResultSet<bool>> Delete(int id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {

                var isDeleted = await _staff_ops.Delete(id);


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

        public async Task<Generic_ResultSet<List<Staff_ResultSet>>> GetAll()
        {
            Generic_ResultSet<List<Staff_ResultSet>> result = new Generic_ResultSet<List<Staff_ResultSet>>();
            try
            {
                List<Staff> Staffs = await _staff_ops.ReadAll();
                result.result_set = new List<Staff_ResultSet>();
                Staffs.ForEach(s =>
                {
                    result.result_set.Add(new Staff_ResultSet
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Username = s.Username,
                        Password = null,
                        AdminId = s.AdminId,
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

        public async Task<Generic_ResultSet<Staff_ResultSet>> Read(int id)
        {
            Generic_ResultSet<Staff_ResultSet> result = new Generic_ResultSet<Staff_ResultSet>();
            try
            {

                var Staff = await _staff_ops.Read(id);

                if (Staff == null)
                {
                    result.success = false;
                    result.userMessage = "Cannot found!";
                    return result;
                }

                result.result_set = new Staff_ResultSet
                {
                    Id = Staff.Id,
                    FirstName = Staff.FirstName,
                    LastName = Staff.LastName,
                    Username = Staff.Username,
                    Password = null,
                    AdminId = Staff.AdminId,
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

        public async Task<Generic_ResultSet<List<Staff_ResultSet>>> GetStaffsByAdmin(int adminId)
        {
            Generic_ResultSet<List<Staff_ResultSet>> result = new Generic_ResultSet<List<Staff_ResultSet>>();
            try
            {
                List<Staff> Staffs = await _staff_ops.GetStaffsByAdmin(adminId);

                if (Staffs == null)
                {
                    return null;
                }

                result.result_set = new List<Staff_ResultSet>();
                Staffs.ForEach(s =>
                {
                    result.result_set.Add(new Staff_ResultSet
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Username = s.Username,
                        Password = null,
                        AdminId = s.AdminId,
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

        public async Task<Generic_ResultSet<Staff_ResultSet>> Update(int id, string fname, string lname, string username, string password)
        {
            Generic_ResultSet<Staff_ResultSet> result = new Generic_ResultSet<Staff_ResultSet>();
            try
            {

                Staff Staff = new Staff
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

                Staff = await _staff_ops.Update(Staff, password);

                if (Staff == null)
                {
                    result.success = false;
                    result.userMessage = "Wrong pass or Username!";
                    return result;
                }

                Staff_ResultSet user = new Staff_ResultSet
                {
                    FirstName = Staff.FirstName,
                    LastName = Staff.LastName,
                    Username = Staff.Username,
                    Password = password,
                };


                result.userMessage = string.Format("updated successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Unit_Service: UpdateUnit() method executed successfully.";
                result.result_set = user;
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
