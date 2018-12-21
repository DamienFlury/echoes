using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchoesServer.Api.Data;
using EchoesServer.Api.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EchoesServer.Api.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public AssignmentsController (SchoolContext context) => _context = context;

        // GET api/values
        [HttpGet]
        [Authorize (AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<IEnumerable<Assignment>> Get ()
        {
            var userName = User.Identity.Name;
            return Ok (_context.Assignments.Where (assignment =>
                assignment.StudentAssignments.Select (sa => sa.Student).Any (student => student.User.UserName == User.Identity.Name)));
        }

        // GET api/values/5        
        [HttpGet ("{id}")]
        public ActionResult<Assignment> Get (int id) => _context.Assignments.Find (id);


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post([FromBody] Assignment assignment) {
            await _context.Assignments.AddAsync(assignment);
            await _context.SaveChangesAsync();
            return Ok(assignment);
        }
    }
}