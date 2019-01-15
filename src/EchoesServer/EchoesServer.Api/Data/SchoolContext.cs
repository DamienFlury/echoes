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
            modelBuilder.Entity<Invitation>().HasKey(inv => new {inv.StudentId, inv.ClassId});
        }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentClass> StudentClasses {get; set;}
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<StudentAssignment> StudentAssignments { get; set; }
    }
}