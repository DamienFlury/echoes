using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchoesServer.Api.Data.Entities;

namespace EchoesServer.Api.Data.DTOs
{
    public class ClassDTO
    {
        public ClassDTO(Class cls) => (Id, Name, Students, Assignments) = (cls.Id, cls.Name,
            cls.StudentClasses?.Select(sc => new StudentDTO(sc.Student)), cls.Assignments?.Select(assignment => new AssignmentDTO(assignment)));

        public ClassDTO()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<StudentDTO> Students { get; set; }
        public IEnumerable<AssignmentDTO> Assignments { get; set; }
    }
}
