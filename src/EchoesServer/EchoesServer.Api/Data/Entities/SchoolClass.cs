using System.Collections.Generic;

namespace EchoesServer.Api.Data.Entities
{
    public class SchoolClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}