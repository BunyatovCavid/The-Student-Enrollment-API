using AutoMapper;
using System.Runtime.InteropServices;
using The_Student_Enrollment_API.Domain.Entities;
using The_Student_Enrollment_API.Dtos;

namespace The_Student_Enrollment_API
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<StudentDto, Student>();
            CreateMap<CourseDto, Course>();
            CreateMap<EnrollmentDto, Enrollment>();
        }
    }
}
