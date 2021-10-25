using LOGIC.Services.Models;
using LOGIC.Services.Models.Act;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IAct_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Act_ResultSet>>> GetAllActs();
        Task<Generic_ResultSet<Act_ResultSet>> GetActById(Int64 id);

        //Task<Generic_ResultSet<Act_ResultSet>> GetActByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Act_ResultSet>> AddAct(string desc, string time, string date, Int64 user_id, string user_name, string lat, string lng);
        Task<Generic_ResultSet<Act_ResultSet>> UpdateAct(Int64 act_id, string desc, string time, string date, Int64 user_id, string user_name, string lat, string lng);
        Task<Generic_ResultSet<bool>> DeleteAct(Int64 id);

    }
}

