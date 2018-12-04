using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchoesServer.Api.Data.Entities;

namespace EchoesServer.Api.Data.DTOs
{
    public class AssignmentDTO
    {
        public AssignmentDTO(Assignment assignment) => (Id, Title, Description, Students, Class) =
            (assignment.Id, assignment.Title, assignment.Description,
                assignment.StudentAssignments?.Select(sa => new StudentDTO(sa.Student)), 
                assignment.Class is null ? null : new ClassDTO(assignment.Class));

        public AssignmentDTO()
        {

        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<StudentDTO> Students { get; set; }
        public ClassDTO Class { get; set; }
    }
}
