using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EchoesServer.Api.Data.Entities
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; } 
        public ICollection<StudentClass> StudentClasses { get; set; }
        public ICollection<StudentAssignment> StudentAssignments { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
    }
}