using System;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using EchoesServer.Api.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EchoesServer.Api.Data
{
    public class SchoolContext : IdentityDbContext<ApplicationUser>
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentAssignment>().HasKey(sa => new {sa.StudentId, sa.AssignmentId});
            modelBuilder.Entity<StudentClass>().HasKey(sc => new {sc.StudentId, sc.ClassId});
            
            var students = Enumerable.Range(1, 50).Select(index => new Student
            {
                Id = index,
                FirstName = "Student" + index,
                LastName = "LastName" + index
            }).ToArray();

            var classes = Enumerable.Range(1, 3).Select(index => new Class
            {
                Id = index,
                Name = "Class" + index
            }).ToArray();

            var studentClasses = new[]
            {
                new StudentClass {StudentId = 1, ClassId = 1},
                new StudentClass {StudentId = 1, ClassId = 2},
                new StudentClass {StudentId = 2, ClassId = 1},
                new StudentClass {StudentId = 2, ClassId = 3}
            }.ToArray();

            var random = new Random();
            var assignments = Enumerable.Range(1, 30).Select(index => new Assignment
            {
                Id = index,
                Title = "Assignment" + index,
                Description = "This is an assignment.",
                ClassId = random.Next(1, 4)
            }).ToArray();

            modelBuilder.Entity<Student>().HasData(students);
            modelBuilder.Entity<Assignment>().HasData(assignments);
            modelBuilder.Entity<Class>().HasData(classes);
            modelBuilder.Entity<StudentClass>().HasData(studentClasses);
        }

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}