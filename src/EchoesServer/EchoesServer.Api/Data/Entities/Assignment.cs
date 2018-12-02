using System.Collections.Generic;

namespace EchoesServer.Api.Data.Entities
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<StudentAssignment> StudentAssignments { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}