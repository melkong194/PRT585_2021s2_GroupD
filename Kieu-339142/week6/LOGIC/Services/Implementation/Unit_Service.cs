using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Unit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{

    public class Unit_Service : IUnit_Service
    {

        private IUnit_Operations _unit_operations = new Unit_Operations();


        public async Task<Generic_ResultSet<List<Unit_ResultSet>>> GetAllUnits()
        {
            Generic_ResultSet<List<Unit_ResultSet>> result = new Generic_ResultSet<List<Unit_ResultSet>>();
            try
            {
                //GET ALL Unit Units
                List<Unit> Units = await _unit_operations.ReadAll();
                //MAP DB Unit RESULTS
                result.result_set = new List<Unit_ResultSet>();
                Units.ForEach(s =>
                {
                    result.result_set.Add(new Unit_ResultSet
                    {
                        unit_id = s.UnitID,
                        name = s.Unit_Name,
                        code = s.Unit_Code,
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


        public async Task<Generic_ResultSet<Unit_ResultSet>> GetUnitById(long id)
        {
            Generic_ResultSet<Unit_ResultSet> result = new Generic_ResultSet<Unit_ResultSet>();
            try
            {

                var Unit = await _unit_operations.Read(id);


                result.result_set = new Unit_ResultSet
                {
                    name = Unit.Unit_Name,
                    unit_id = Unit.UnitID,
                    code = Unit.Unit_Code,
                };


                result.userMessage = string.Format("Get ByID - Unit  obtained successfully");
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



        public async Task<Generic_ResultSet<Unit_ResultSet>> AddUnit(string name, string code)
        {
            Generic_ResultSet<Unit_ResultSet> result = new Generic_ResultSet<Unit_ResultSet>();
            try
            {

                Unit Unit = new Unit
                {
                    Unit_Name = name,
                    Unit_Code = code
                };


                Unit = await _unit_operations.Create(Unit);


                Unit_ResultSet unitAdded = new Unit_ResultSet
                {
                    code = Unit.Unit_Code,
                    name = Unit.Unit_Name,
                    unit_id = Unit.UnitID
                };


                result.userMessage = string.Format("The supplied Unit Unit {0} was added successfully", name, code);
                result.internalMessage = "LOGIC.Services.Implementation.Unit_Service: AddUnit() method executed successfully.";
                result.result_set = unitAdded;
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


        public async Task<Generic_ResultSet<Unit_ResultSet>> UpdateUnit(Int64 unit_id, string name, string code)
        {
            Generic_ResultSet<Unit_ResultSet> result = new Generic_ResultSet<Unit_ResultSet>();
            try
            {
                Unit Unit = new Unit
                {
                    UnitID = unit_id,
                    Unit_Name = name,
                    Unit_Code = code,
                };

                Unit = await _unit_operations.Update(Unit, unit_id);

                Unit_ResultSet unitUpdated = new Unit_ResultSet
                {
                    name = Unit.Unit_Name,
                    unit_id = Unit.UnitID,
                    code = Unit.Unit_Code,
                };


                result.userMessage = string.Format("The supplied Unit was updated successfully", name, code);
                result.internalMessage = "LOGIC.Services.Implementation.Unit_Service: UpdateUnit() method executed successfully.";
                result.result_set = unitUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {

                result.exception = exception;
                result.userMessage = "We failed to update your information for the Unit Unit supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Unit_Service: UpdateUnit(): {0}", exception.Message); ;
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteUnit(long unit_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {

                var unitDeleted = await _unit_operations.Delete(unit_id);


                result.userMessage = string.Format("The supplied Unit Unit {0} was deleted successfully", unit_id);
                result.internalMessage = "LOGIC.Services.Implementation.Unit_Service: DeleteUnit() method executed successfully.";
                result.result_set = unitDeleted;
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
    }

}
