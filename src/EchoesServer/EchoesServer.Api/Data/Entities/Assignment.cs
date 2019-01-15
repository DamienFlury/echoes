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
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueTo { get; set; }
        public ICollection<StudentAssignment> StudentAssignments { get; set; }

        [Required]
        public int ClassId { get; set; }
        public Class Class { get; set; }
                
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}