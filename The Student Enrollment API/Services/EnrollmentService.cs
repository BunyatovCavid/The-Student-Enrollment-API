using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class EnrollmentService : IEnrollment
    {
        EducationContex ed;
        IMapper _mapper;
        public EnrollmentService(IMapper mapper)
        {
            ed = new();
            _mapper = mapper;
        }

        public async Task<List<Enrollment>> GetEnrollment()
        {
            try
            {
                var data = await ed.Enrollments.Include(e => e.Student).Include(e => e.Course).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public Task<Enrollment> GetEnrollmentByID(int id)
        {
            try
            {
                var data = ed.Enrollments.Include(e => e.Student).Include(e => e.Course).FirstOrDefaultAsync(e => e.Id == id);
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

        public async Task<Enrollment> PostEnrollment(EnrollmentDto enrollmentDto)
        {
            try
            {
                var new_post = _mapper.Map<Enrollment>(enrollmentDto);
                var data_student = await ed.Students.FirstOrDefaultAsync(s => s.Id == new_post.StudentId);
                var data_course = await ed.Courses.FirstOrDefaultAsync(c => c.Id == new_post.CourseID);
                var data_enrollment = await ed.Enrollments.Where(c => c.CourseID == new_post.CourseID).FirstOrDefaultAsync(c => c.StudentId == new_post.StudentId);

                if (data_student != null && data_course != null)
                {
                    if (data_enrollment == null)
                    {
                        await ed.Enrollments.AddAsync(new_post);
                        await ed.SaveChangesAsync();
                        var return_value = await ed.Enrollments.OrderByDescending(c => c.Course).Include(e => e.Student).Include(e => e.Course).FirstOrDefaultAsync(e => e.Grade == new_post.Grade);
                        return return_value;
                    }
                    else return null;
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

        public async Task<Enrollment> PutEnrollment(int id, EnrollmentDto enrollmentDto)
        {
            try
            {
                var data = await ed.Enrollments.FirstOrDefaultAsync(e => e.Id == id);
                if (data != null)
                {
                    var return_value = _mapper.Map(enrollmentDto, data);
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

        public async Task<string> DeleteEnrollment(int id)
        {
            try
            {
                var data = await ed.Enrollments.FirstOrDefaultAsync(e => e.Id == id);
                if (data != null)
                {
                    ed.Enrollments.Remove(data);
                    await ed.SaveChangesAsync();
                    return "Successful";
                }
                else return "Failed";
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
