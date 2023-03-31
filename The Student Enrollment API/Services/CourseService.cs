using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Student_Enrollment_API.Domain;
using The_Student_Enrollment_API.Domain.Entities;
using The_Student_Enrollment_API.Dtos;
using The_Student_Enrollment_API.Interfaces;

namespace The_Student_Enrollment_API.Services
{
    public class CourseService : ICourse
    {
        EducationContex ed;
        IMapper _mapper;
        public CourseService(IMapper mapper)
        {
            ed = new();
            _mapper = mapper;
        }

        public async Task<List<Course>> GetCourse()
        {
            try
            {
                var data = await ed.Courses.Include(c => c.Enrollments).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<Course> GetCourseByID(int id)
        {
            try
            {
                var data = await ed.Courses.Include(c => c.Enrollments).FirstOrDefaultAsync(c => c.Id == id);
                if (data != null) return data;
                else return null;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<Course> PostCourse(CourseDto courseDto)
        {
            try
            {
                var new_post = _mapper.Map<Course>(courseDto);
                await ed.Courses.AddAsync(new_post);
                await ed.SaveChangesAsync();
                var return_value = await ed.Courses.OrderByDescending(c => c.Id).FirstOrDefaultAsync(c => c.Name == new_post.Name);
                return return_value;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException; 
                return null;
            }
        }

        public async Task<Course> PutCourse(int id, CourseDto courseDto)
        {
            try
            {
                var data = await ed.Courses.FirstOrDefaultAsync(c => c.Id == id);
                if (data != null)
                {
                    var return_value = _mapper.Map(courseDto, data);
                    await ed.SaveChangesAsync();
                    return return_value;
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
        public async Task<string> DeleteCourse(int id)
        {
            try
            {
                var data = await ed.Courses.FirstOrDefaultAsync(c => c.Id == id);
                if (data != null)
                {
                    ed.Courses.Remove(data);
                    await ed.SaveChangesAsync();
                    return "Succesful";
                }
                else return "This id is not regestred";
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return "Failed";
                throw;
            }
        }

    }
}
