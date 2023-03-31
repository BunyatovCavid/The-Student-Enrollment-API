using System.Collections.Generic;
using System.Threading.Tasks;
using The_Student_Enrollment_API.Domain.Entities;
using The_Student_Enrollment_API.Dtos;

namespace The_Student_Enrollment_API.Interfaces
{
    public interface ICourse
    {
        public Task<List<Course>> GetCourse();
        public Task<Course> GetCourseByID(int id);
        public Task<Course> PostCourse(CourseDto CourseDto);
        public Task<Course> PutCourse(int id, CourseDto CourseDto);
        public Task<string> DeleteCourse(int id);
    }
}
