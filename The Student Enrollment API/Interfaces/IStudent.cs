using System.Collections.Generic;
using System.Threading.Tasks;
using The_Student_Enrollment_API.Domain.Entities;
using The_Student_Enrollment_API.Dtos;

namespace The_Student_Enrollment_API.Interfaces
{
    public interface IStudent
    { 
        public Task<List<Student>> GetStudent();
        public Task<Student> GetStudentByID(int id);
        public Task<Student> PostStudent(StudentDto studentDto);
        public Task<Student> PutStudent(int id, StudentDto studentDto);
        public Task<string> DeleteStudent(int id);

    }
}
