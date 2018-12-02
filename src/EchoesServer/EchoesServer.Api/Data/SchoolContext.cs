using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using EchoesServer.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EchoesServer.Api.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var students = Enumerable.Range(1, 50).Select(index => new Student
            {
                Id = index,
                FirstName = "Student" + index,
                LastName = "LastName" + index
            }).ToArray();

            var assignments = Enumerable.Range(1, 30).Select(index => new Assignment
            {
                Id = index,
                Title = "Assignment" + index,
                Description = "This is an assignment."
            }).ToArray();

            var classes = Enumerable.Range(1, 3).Select(index => new SchoolClass
            {
                Id = index,
                Name = "Class" + index
            }).ToArray();

            modelBuilder.Entity<Student>().HasData(students);
            modelBuilder.Entity<Assignment>().HasData(assignments);
            modelBuilder.Entity<SchoolClass>().HasData(classes);
        }

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}