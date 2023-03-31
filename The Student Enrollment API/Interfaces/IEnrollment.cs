using System.Collections.Generic;
using System.Threading.Tasks;
using The_Student_Enrollment_API.Domain.Entities;
using The_Student_Enrollment_API.Dtos;

namespace The_Student_Enrollment_API.Interfaces
{
    public interface IEnrollment
    {
        public Task<List<Enrollment>> GetEnrollment();
        public Task<Enrollment> GetEnrollmentByID(int id);
        public Task<Enrollment> PostEnrollment(EnrollmentDto EnrollmentDto);
        public Task<Enrollment> PutEnrollment(int id, EnrollmentDto EnrollmentDto);
        public Task<string> DeleteEnrollment(int id);
    }
}
