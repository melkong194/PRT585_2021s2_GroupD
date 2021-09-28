using LOGIC.Services.Models;
using LOGIC.Services.Models.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface ICourse_Service
    {
        Task<Generic_ResultSet<List<Course_ResultSet>>> GetAllCourses();
        Task<Generic_ResultSet<Course_ResultSet>> GetCourseById(Int64 id);
        Task<Generic_ResultSet<Course_ResultSet>> AddCourse(string name, string code);
        Task<Generic_ResultSet<Course_ResultSet>> UpdateCourse(Int64 id, string name, string code);
        Task<Generic_ResultSet<bool>> DeleteCourse(Int64 id);
    }
}
