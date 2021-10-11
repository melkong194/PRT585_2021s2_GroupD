using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Act;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Act act Data
    /// </summary>
    public class Act_Service : IAct_Service
    {
        //Reference to our crud functions
        private IAct_Operations _act_operations = new Act_Operations();

        /// <summary>
        /// Obtains all the Act actes that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Act_ResultSet>>> GetAllActs()
        {
            Generic_ResultSet<List<Act_ResultSet>> result = new Generic_ResultSet<List<Act_ResultSet>>();
            try
            {
                //GET ALL Act actES
                List<Act> Actes = await _act_operations.ReadAll();
                //MAP DB Act RESULTS
                result.result_set = new List<Act_ResultSet>();
                Actes.ForEach(s =>
                {
                    result.result_set.Add(new Act_ResultSet
                    {
                        act_id = s.ActID,
                        desc = s.Act_Desc,
                        time = s.Act_Time,
                        date = s.Act_Date,
                        user_id = s.Act_userID,
                        user_name = s.Act_userName
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Act actes obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Act_Service: GetAllActs() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Act actes from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Act_Service: GetAllActs(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Act_ResultSet>> GetActById(long id)
        {
            Generic_ResultSet<Act_ResultSet> result = new Generic_ResultSet<Act_ResultSet>();
            try
            {
                //GET by ID Act 
                var Act = await _act_operations.Read(id);

                //MAP DB Act RESULTS
                result.result_set = new Act_ResultSet
                {
                    act_id = Act.ActID,
                    desc = Act.Act_Desc,
                    time = Act.Act_Time,
                    date = Act.Act_Date,
                    user_id = Act.Act_userID,
                    user_name = Act.Act_userName
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Act  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Act_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Act  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Act_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new act to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Act_ResultSet>> AddAct(string desc, string time, string date, Int64 user_id, string user_name)
        {
            Generic_ResultSet<Act_ResultSet> result = new Generic_ResultSet<Act_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Act
                Act Act = new Act
                {
                    Act_Desc = desc,
                    Act_Time = time,
                    Act_Date = date,
                    Act_userID = user_id,
                    Act_userName = user_name
                };

                //ADD Act TO DB
                Act = await _act_operations.Create(Act);

                //MANUAL MAPPING OF RETURNED Act VALUES TO OUR Act_ResultSet
                Act_ResultSet actAdded = new Act_ResultSet
                {
                    act_id = Act.ActID,
                    desc = Act.Act_Desc,
                    time = Act.Act_Time,
                    date = Act.Act_Date,
                    user_id = Act.Act_userID,
                    user_name = Act.Act_userName
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Act act {0} was added successfully", user_name);
                result.internalMessage = "LOGIC.Services.Implementation.Act_Service: AddAct() method executed successfully.";
                result.result_set = actAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Act act supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Act_Service: AddAct(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an Act acts name.
        /// </summary>
        /// <param name="act_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Act_ResultSet>> UpdateAct(Int64 act_id, string desc, string time, string date, Int64 user_id, string user_name)
        {
            Generic_ResultSet<Act_ResultSet> result = new Generic_ResultSet<Act_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Act
                Act Act = new Act
                {
                    ActID = act_id,
                    Act_Desc = desc,
                    Act_Time = time,
                    Act_Date = date,
                    Act_userID = user_id,
                    Act_userName = user_name
                    //Act_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Act IN DB
                Act = await _act_operations.Update(Act, act_id);

                //MANUAL MAPPING OF RETURNED Act VALUES TO OUR Act_ResultSet
                Act_ResultSet actUpdated = new Act_ResultSet
                {
                    act_id = Act.ActID,
                    desc = Act.Act_Desc,
                    time = Act.Act_Time,
                    date = Act.Act_Date,
                    user_id = Act.Act_userID,
                    user_name = Act.Act_userName
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Act act {0} was updated successfully", user_name);
                result.internalMessage = "LOGIC.Services.Implementation.Act_Service: UpdateAct() method executed successfully.";
                result.result_set = actUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Act act supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Act_Service: UpdateAct(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteAct(long act_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Act IN DB
                var actDeleted = await _act_operations.Delete(act_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Act act {0} was deleted successfully", act_id);
                result.internalMessage = "LOGIC.Services.Implementation.Act_Service: DeleteAct() method executed successfully.";
                result.result_set = actDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Act act supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Act_Service: DeleteAct(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }
}
