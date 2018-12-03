using System.Collections.Generic;

namespace EchoesServer.Api.Data.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<StudentClass> StudentClasses { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}