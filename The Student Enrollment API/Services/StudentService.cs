using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using The_Student_Enrollment_API.Domain;
using The_Student_Enrollment_API.Domain.Entities;
using The_Student_Enrollment_API.Dtos;
using The_Student_Enrollment_API.Interfaces;

namespace The_Student_Enrollment_API.Services
{
    public class StudentService : IStudent
    {
        EducationContex ed;
        IMapper _mapper;
        public StudentService(IMapper mapper)
        {
            ed = new();
            _mapper = mapper;
        }

        public async Task<List<Student>> GetStudent()
        {
            try
            {
                var data = await ed.Students.Include(e => e.Enrollments).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<Student> GetStudentByID(int id)
        {
            try
            {
                var data = await ed.Students.Include(s => s.Enrollments).FirstOrDefaultAsync(s => s.Id == id);
                if (data != null)
                {
                    return data;
                }
                else return null;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<Student> PostStudent(StudentDto studentDto)
        {
            try
            {
                var new_post = _mapper.Map<Student>(studentDto);
                await ed.Students.AddAsync(new_post);
                await ed.SaveChangesAsync();
                var return_value = await ed.Students.OrderByDescending(s => s.Id).FirstOrDefaultAsync(s => s.Name == new_post.Name);
                return return_value;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<Student> PutStudent(int id, StudentDto studentDto)
        {
            try
            {
                var data = await ed.Students.FirstOrDefaultAsync(s => s.Id == id);
                if (data != null)
                {
                    var return_value = _mapper.Map(studentDto, data);
                    await ed.SaveChangesAsync();
                    return return_value;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<string> DeleteStudent(int id)
        {
            try
            {
                var data = await ed.Students.FirstOrDefaultAsync(s => s.Id == id);
                if (data != null)
                {
                    ed.Students.Remove(data);
                    await ed.SaveChangesAsync();
                    return "Succesful";
                }
                else return "This id is not registered";
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return "Failed";
            }
        }
    }


}

