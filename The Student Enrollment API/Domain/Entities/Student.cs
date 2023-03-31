using Newtonsoft.Json;
using System.Collections.Generic;

namespace The_Student_Enrollment_API.Domain.Entities
{
    public class Student
    {
        public Student()
        {
            Enrollments = new HashSet<Enrollment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
