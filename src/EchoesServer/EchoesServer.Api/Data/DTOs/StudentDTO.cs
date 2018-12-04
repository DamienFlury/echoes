using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchoesServer.Api.Data.Entities;

namespace EchoesServer.Api.Data.DTOs
{
    public class StudentDTO
    {
        public StudentDTO(Student student) => (Id, FirstName, LastName, Classes, Assignments) =
            (student.Id, student.FirstName, student.LastName,
                student.StudentClasses?.Select(sc => new ClassDTO(sc.Class)),
                student.StudentAssignments?.Select(sa => new AssignmentDTO(sa.Assignment)));

        public StudentDTO()
        {
            
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<ClassDTO> Classes { get; set; }
        public IEnumerable<AssignmentDTO> Assignments { get; set; }
    }
}
