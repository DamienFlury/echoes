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

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}