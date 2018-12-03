using System.Collections;
using System.Collections.Generic;

namespace EchoesServer.Api.Data.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public ICollection<StudentClass> StudentClasses { get; set; }
        public ICollection<StudentAssignment> StudentAssignments { get; set; }
    }
}