using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Course;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{

    public class Course_Service : ICourse_Service
    {

        private ICourse_Operations _course_operations = new Course_Operations();


        public async Task<Generic_ResultSet<List<Course_ResultSet>>> GetAllCourses()
        {
            Generic_ResultSet<List<Course_ResultSet>> result = new Generic_ResultSet<List<Course_ResultSet>>();
            try
            {
                //GET ALL Course Courses
                List<Course> Courses = await _course_operations.ReadAll();
                //MAP DB Course RESULTS
                result.result_set = new List<Course_ResultSet>();
                Courses.ForEach(s =>
                {
                    result.result_set.Add(new Course_ResultSet
                    {
                        course_id = s.CourseID,
                        name = s.Course_Name,
                        code = s.Course_Code,
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Course Courses obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Course_Service: GetAllCourses() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Course Courses from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Course_Service: GetAllCourses(): {0}", exception.Message); ;
            }
            return result;
        }


        public async Task<Generic_ResultSet<Course_ResultSet>> GetCourseById(long id)
        {
            Generic_ResultSet<Course_ResultSet> result = new Generic_ResultSet<Course_ResultSet>();
            try
            {

                var Course = await _course_operations.Read(id);


                result.result_set = new Course_ResultSet
                {
                    name = Course.Course_Name,
                    course_id = Course.CourseID,
                    code = Course.Course_Code,
                };


                result.userMessage = string.Format("Get ByID - Course  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Course_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Course  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Course_Service: Get ByID(): {0}", exception.Message); ;
            }
            return result;
        }



        public async Task<Generic_ResultSet<Course_ResultSet>> AddCourse(string name, string code)
        {
            Generic_ResultSet<Course_ResultSet> result = new Generic_ResultSet<Course_ResultSet>();
            try
            {

                Course Course = new Course
                {
                    Course_Name = name,
                    Course_Code = code
                };


                Course = await _course_operations.Create(Course);


                Course_ResultSet courseAdded = new Course_ResultSet
                {
                    code = Course.Course_Code,
                    name = Course.Course_Name,
                    course_id = Course.CourseID
                };


                result.userMessage = string.Format("The supplied Course Course {0} was added successfully", name, code);
                result.internalMessage = "LOGIC.Services.Implementation.Course_Service: AddCourse() method executed successfully.";
                result.result_set = courseAdded;
                result.success = true;
            }
            catch (Exception exception)
            {

                result.exception = exception;
                result.userMessage = "We failed to register your information for the Course Course supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Course_Service: AddCourse(): {0}", exception.Message); ;
            }
            return result;
        }


        public async Task<Generic_ResultSet<Course_ResultSet>> UpdateCourse(Int64 course_id, string name, string code)
        {
            Generic_ResultSet<Course_ResultSet> result = new Generic_ResultSet<Course_ResultSet>();
            try
            {
                Course Course = new Course
                {
                    CourseID = course_id,
                    Course_Name = name,
                    Course_Code = code,
                };

                Course = await _course_operations.Update(Course, course_id);

                Course_ResultSet courseUpdated = new Course_ResultSet
                {
                    name = Course.Course_Name,
                    course_id = Course.CourseID,
                    code = Course.Course_Code,
                };


                result.userMessage = string.Format("The supplied Course was updated successfully", name, code);
                result.internalMessage = "LOGIC.Services.Implementation.Course_Service: UpdateCourse() method executed successfully.";
                result.result_set = courseUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {

                result.exception = exception;
                result.userMessage = "We failed to update your information for the Course Course supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Course_Service: UpdateCourse(): {0}", exception.Message); ;
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteCourse(long course_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {

                var courseDeleted = await _course_operations.Delete(course_id);


                result.userMessage = string.Format("The supplied Course Course {0} was deleted successfully", course_id);
                result.internalMessage = "LOGIC.Services.Implementation.Course_Service: DeleteCourse() method executed successfully.";
                result.result_set = courseDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Course Course supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Course_Service: DeleteCourse(): {0}", exception.Message); ;
            }
            return result;
        }
    }

}
