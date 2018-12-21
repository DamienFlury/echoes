using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EchoesServer.Api.Data.Entities
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<StudentAssignment> StudentAssignments { get; set; }

        [Required]
        public int ClassId { get; set; }
        [Required]
        public Class Class { get; set; }
    }
}