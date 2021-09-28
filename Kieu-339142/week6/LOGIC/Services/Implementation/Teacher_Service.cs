using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
  
    public class Teacher_Service : ITeacher_Service
    {

        private ITeacher_Operations _teacher_operations = new Teacher_Operations();


        public async Task<Generic_ResultSet<List<Teacher_ResultSet>>> GetAllTeachers()
        {
            Generic_ResultSet<List<Teacher_ResultSet>> result = new Generic_ResultSet<List<Teacher_ResultSet>>();
            try
            {
                //GET ALL Teacher Teachers
                List<Teacher> Teachers = await _teacher_operations.ReadAll();
                //MAP DB Teacher RESULTS
                result.result_set = new List<Teacher_ResultSet>();
                Teachers.ForEach(s =>
                {
                    result.result_set.Add(new Teacher_ResultSet
                    {
                        teacher_id = s.TeacherID,
                        name = s.Teacher_Name,
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Teacher Teachers obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Teacher_Service: GetAllTeachers() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Teacher Teachers from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Teacher_Service: GetAllTeachers(): {0}", exception.Message); ;
            }
            return result;
        }


        public async Task<Generic_ResultSet<Teacher_ResultSet>> GetTeacherById(long id)
        {
            Generic_ResultSet<Teacher_ResultSet> result = new Generic_ResultSet<Teacher_ResultSet>();
            try
            {

                var Teacher = await _teacher_operations.Read(id);


                result.result_set = new Teacher_ResultSet
                {
                    name = Teacher.Teacher_Name,
                    teacher_id = Teacher.TeacherID
                };


                result.userMessage = string.Format("Get ByID - Teacher  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Teacher_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Teacher  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Teacher_Service: Get ByID(): {0}", exception.Message); ;
            }
            return result;
        }



        public async Task<Generic_ResultSet<Teacher_ResultSet>> AddTeacher(string name)
        {
            Generic_ResultSet<Teacher_ResultSet> result = new Generic_ResultSet<Teacher_ResultSet>();
            try
            {

                Teacher Teacher = new Teacher
                {
                    Teacher_Name = name
                };


                Teacher = await _teacher_operations.Create(Teacher);


                Teacher_ResultSet teacherAdded = new Teacher_ResultSet
                {
                    name = Teacher.Teacher_Name,
                    teacher_id = Teacher.TeacherID
                };


                result.userMessage = string.Format("The supplied Teacher Teacher {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Teacher_Service: AddTeacher() method executed successfully.";
                result.result_set = teacherAdded;
                result.success = true;
            }
            catch (Exception exception)
            {

                result.exception = exception;
                result.userMessage = "We failed to register your information for the Teacher Teacher supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Teacher_Service: AddTeacher(): {0}", exception.Message); ;
            }
            return result;
        }


        public async Task<Generic_ResultSet<Teacher_ResultSet>> UpdateTeacher(Int64 teacher_id, string name)
        {
            Generic_ResultSet<Teacher_ResultSet> result = new Generic_ResultSet<Teacher_ResultSet>();
            try
            {
                Teacher Teacher = new Teacher
                {
                    TeacherID = teacher_id,
                    Teacher_Name = name,
                };

                Teacher = await _teacher_operations.Update(Teacher, teacher_id);

                Teacher_ResultSet teacherUpdated = new Teacher_ResultSet
                {
                    name = Teacher.Teacher_Name,
                    teacher_id = Teacher.TeacherID
                };


                result.userMessage = string.Format("The supplied Teacher was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Teacher_Service: UpdateTeacher() method executed successfully.";
                result.result_set = teacherUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {

                result.exception = exception;
                result.userMessage = "We failed to update your information for the Teacher Teacher supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Teacher_Service: UpdateTeacher(): {0}", exception.Message); ;
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteTeacher(long teacher_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {

                var teacherDeleted = await _teacher_operations.Delete(teacher_id);


                result.userMessage = string.Format("The supplied Teacher Teacher {0} was deleted successfully", teacher_id);
                result.internalMessage = "LOGIC.Services.Implementation.Teacher_Service: DeleteTeacher() method executed successfully.";
                result.result_set = teacherDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Teacher Teacher supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Teacher_Service: DeleteTeacher(): {0}", exception.Message); ;
            }
            return result;
        }
    }
   
}
