using LOGIC.Services.Models;
using LOGIC.Services.Models.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IUnit_Service
    {
        Task<Generic_ResultSet<List<Unit_ResultSet>>> GetAllUnits();
        Task<Generic_ResultSet<Unit_ResultSet>> GetUnitById(Int64 id);
        Task<Generic_ResultSet<Unit_ResultSet>> AddUnit(string name, string code);
        Task<Generic_ResultSet<Unit_ResultSet>> UpdateUnit(Int64 id, string name, string code);
        Task<Generic_ResultSet<bool>> DeleteUnit(Int64 id);
    }
}
