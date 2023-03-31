using System.Collections.Generic;

namespace The_Student_Enrollment_API.Domain.Entities
{
    public class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
