using Microsoft.EntityFrameworkCore;
using The_Student_Enrollment_API.Domain.Entities;

namespace The_Student_Enrollment_API.Domain
{
    public class EducationContex : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }


       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WIN-PFGV5N8DK24;Database=Education;Trusted_Connection=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                 .HasOne(e => e.Student)
                 .WithMany(s => s.Enrollments)
                 .HasForeignKey(e => e.StudentId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Enrollment>()
                 .HasKey(e => e.Id);

            modelBuilder.Entity<Enrollment>()
             .HasIndex(e => new { e.StudentId, e.CourseID })
             .IsUnique();

        }
    }
}
