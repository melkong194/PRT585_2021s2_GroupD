using LOGIC.Services.Models;
using LOGIC.Services.Models.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IEvent_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Event_ResultSet>>> GetAllEvents();
        Task<Generic_ResultSet<Event_ResultSet>> GetEventById(Int64 id);

        //Task<Generic_ResultSet<Event_ResultSet>> GetEventByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Event_ResultSet>> AddEvent(Int64 user_id, string user_name, string title, string start, string end, string recurrence_rule);
        Task<Generic_ResultSet<Event_ResultSet>> UpdateEvent(Int64 event_id, Int64 user_id, string user_name, string title, string start, string end, string recurrence_rule);
        Task<Generic_ResultSet<bool>> DeleteEvent(Int64 id);

    }
}

