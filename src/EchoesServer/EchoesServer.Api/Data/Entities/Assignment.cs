using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EchoesServer.Api.Data.Entities
{
    public class Assignment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime DueTo { get; set; }
        public ICollection<StudentAssignment> StudentAssignments { get; set; }

        [Required]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
                
        public int? StudentId { get; set; }
        public Student Student { get; set; }
    }
}