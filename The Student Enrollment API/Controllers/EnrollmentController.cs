using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using The_Student_Enrollment_API.Domain.Entities;
using The_Student_Enrollment_API.Dtos;
using The_Student_Enrollment_API.Interfaces;

namespace The_Student_Enrollment_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollment _Enrollment;

        public EnrollmentController(IEnrollment Enrollment)
        {
            _Enrollment = Enrollment;
        }

        [HttpGet]
        public async Task<List<Enrollment>> GetEnrollmentAsync()
        {
            var data = await _Enrollment.GetEnrollment();
            return data;
        }
        [HttpGet("{id}")]
        public async Task<Enrollment> GetEnrollmentBYAsync([FromQuery] int id)
        {
            var data = await _Enrollment.GetEnrollmentByID(id);
            return data;
        }

        [HttpPost]
        public async Task<Enrollment> PostEnrollmentAsync([FromQuery] EnrollmentDto EnrollmentDto)
        {
            var data = await _Enrollment.PostEnrollment(EnrollmentDto);
            return data;
        }
        [HttpPut]
        public async Task<Enrollment> PutEnrollmentAsync([FromQuery] int id, [FromQuery] EnrollmentDto EnrollmentDto)
        {
            var data = await _Enrollment.PutEnrollment(id, EnrollmentDto);
            return data;
        }
        [HttpDelete]
        public async Task<string> DeleteEnrollmentAsync([FromQuery] int id)
        {
            var data = await _Enrollment.DeleteEnrollment(id);
            return data;
        }
    }
}
