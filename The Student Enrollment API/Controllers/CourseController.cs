using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using The_Student_Enrollment_API.Domain;
using The_Student_Enrollment_API.Domain.Entities;
using The_Student_Enrollment_API.Dtos;
using The_Student_Enrollment_API.Interfaces;

namespace The_Student_Enrollment_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {

        private readonly ICourse _course;

        public CourseController(ICourse course)
        {
            _course = course;
        }

        [HttpGet]
        public async Task<List<Course>> GetCourseAsync()
        {
            var data = await _course.GetCourse();
            return data;
        }
        [HttpGet("{id}")]
        public async Task<Course> GetCourseBYAsync([FromQuery] int id)
        {
            var data = await _course.GetCourseByID(id);
            return data;
        }

        [HttpPost]
        public async Task<Course> PostCourseAsync([FromQuery] CourseDto courseDto)
        {
            var data = await _course.PostCourse(courseDto);
            return data;
        }
        [HttpPut]
        public async Task<Course> PutCourseAsync([FromQuery] int id, [FromQuery] CourseDto courseDto)
        {
            var data = await _course.PutCourse(id, courseDto);
            return data;
        }
        [HttpDelete]
        public async Task<string> DeleteCourseAsync([FromQuery] int id)
        {
            var data = await _course.DeleteCourse(id);
            return data;
        }
    }
}
