using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Student_Enrollment_API.Domain.Entities;
using The_Student_Enrollment_API.Dtos;
using The_Student_Enrollment_API.Interfaces;
using The_Student_Enrollment_API.Services;

namespace The_Student_Enrollment_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _Student;

        public StudentController(IStudent Student)
        {
            _Student = Student;
        }

        [HttpGet]
        public async Task<List<Student>>  GetStudentAsync()
        {
                var data = await _Student.GetStudent();
                return data;
           
        }
        [HttpGet("{id}")]
        public async Task<Student> GetStudentBYAsync([FromQuery] int id)
        {
            var data = await _Student.GetStudentByID(id);
            return data;
        }

        [HttpPost]
        public async Task<Student> PostStudentAsync([FromQuery] StudentDto StudentDto)
        {
            var data = await _Student.PostStudent(StudentDto);
            return data;
        }
        [HttpPut]
        public async Task<Student> PutStudentAsync([FromQuery] int id, [FromQuery] StudentDto StudentDto)
        {
            var data = await _Student.PutStudent(id, StudentDto);
            return data;
        }
        [HttpDelete]
        public async Task<string> DeleteStudentAsync([FromQuery] int id)
        {
            var data = await _Student.DeleteStudent(id);
            return data;
        }
    }
}
