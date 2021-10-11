using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Event;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Event event Data
    /// </summary>
    public class Event_Service : IEvent_Service
    {
        //Reference to our crud functions
        private IEvent_Operations _event_operations = new Event_Operations();

        /// <summary>
        /// Obtains all the Event eventes that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Event_ResultSet>>> GetAllEvents()
        {
            Generic_ResultSet<List<Event_ResultSet>> result = new Generic_ResultSet<List<Event_ResultSet>>();
            try
            {
                //GET ALL Event eventES
                List<Event> Eventes = await _event_operations.ReadAll();
                //MAP DB Event RESULTS
                result.result_set = new List<Event_ResultSet>();
                Eventes.ForEach(s =>
                {
                    result.result_set.Add(new Event_ResultSet
                    {
                        event_id = s.EventID,
                        user_id = s.Event_userID,
                        user_name = s.Event_userName,
                        title = s.Event_Title,
                        start = s.Event_Start,
                        end = s.Event_End,
                        recurrence_rule = s.Event_RecurrenceRule
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Event eventes obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Event_Service: GetAllEvents() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Event eventes from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Event_Service: GetAllEvents(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Event_ResultSet>> GetEventById(long id)
        {
            Generic_ResultSet<Event_ResultSet> result = new Generic_ResultSet<Event_ResultSet>();
            try
            {
                //GET by ID Event 
                var Event = await _event_operations.Read(id);

                //MAP DB Event RESULTS
                result.result_set = new Event_ResultSet
                {
                    event_id = Event.EventID,
                    user_id = Event.Event_userID,
                    user_name = Event.Event_userName,
                    title = Event.Event_Title,
                    start = Event.Event_Start,
                    end = Event.Event_End,
                    recurrence_rule = Event.Event_RecurrenceRule
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Event  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Event_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Event  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Event_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new event to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Event_ResultSet>> AddEvent(Int64 user_id, string user_name, string title, string start, string end, string recurrence_rule)
        {
            Generic_ResultSet<Event_ResultSet> result = new Generic_ResultSet<Event_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Event
                Event Event = new Event
                {
                    Event_userID = user_id,
                    Event_userName = user_name,
                    Event_Title = title,
                    Event_Start = start,
                    Event_End = end, 
                    Event_RecurrenceRule = recurrence_rule
                };

                //ADD Event TO DB
                Event = await _event_operations.Create(Event);

                //MANUAL MAPPING OF RETURNED Event VALUES TO OUR Event_ResultSet
                Event_ResultSet eventAdded = new Event_ResultSet
                {
                    event_id = Event.EventID,
                    user_id = Event.Event_userID,
                    user_name = Event.Event_userName,
                    title = Event.Event_Title,
                    start = Event.Event_Start,
                    end = Event.Event_End,
                    recurrence_rule = Event.Event_RecurrenceRule
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Event event {0} was added successfully", title);
                result.internalMessage = "LOGIC.Services.Implementation.Event_Service: AddEvent() method executed successfully.";
                result.result_set = eventAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Event event supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Event_Service: AddEvent(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an Event events name.
        /// </summary>
        /// <param name="event_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Event_ResultSet>> UpdateEvent(Int64 event_id, Int64 user_id, string user_name, string title, string start, string end, string recurrence_rule)
        {
            Generic_ResultSet<Event_ResultSet> result = new Generic_ResultSet<Event_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Event
                Event Event = new Event
                {
                    EventID = event_id,
                    Event_userID = user_id,
                    Event_userName = user_name,
                    Event_Title = title,
                    Event_Start = start,
                    Event_End = end,
                    Event_RecurrenceRule = recurrence_rule
                    //Event_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Event IN DB
                Event = await _event_operations.Update(Event, event_id);

                //MANUAL MAPPING OF RETURNED Event VALUES TO OUR Event_ResultSet
                Event_ResultSet eventUpdated = new Event_ResultSet
                {
                    event_id = Event.EventID,
                    user_id = Event.Event_userID,
                    user_name = Event.Event_userName,
                    title = Event.Event_Title,
                    start = Event.Event_Start,
                    end = Event.Event_End,
                    recurrence_rule = Event.Event_RecurrenceRule
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Event event {0} was updated successfully", title);
                result.internalMessage = "LOGIC.Services.Implementation.Event_Service: UpdateEvent() method executed successfully.";
                result.result_set = eventUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Event event supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Event_Service: UpdateEvent(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteEvent(long event_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Event IN DB
                var eventDeleted = await _event_operations.Delete(event_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Event event {0} was deleted successfully", event_id);
                result.internalMessage = "LOGIC.Services.Implementation.Event_Service: DeleteEvent() method executed successfully.";
                result.result_set = eventDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Event event supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Event_Service: DeleteEvent(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }
}
