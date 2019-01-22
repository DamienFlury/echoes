using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchoesServer.Api.Data;
using EchoesServer.Api.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens.Saml2;

namespace EchoesServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AssignmentsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public AssignmentsController(SchoolContext context) => _context = context;

        private IQueryable<Assignment> GetAll() =>
            from assignment in _context.Assignments
            join cls in _context.Classes on assignment.ClassId equals cls.Id
            join sc in _context.StudentClasses on cls.Id equals sc.ClassId
            join student in _context.Students on sc.StudentId equals student.Id
            where student.User.UserName == User.Identity.Name
            select assignment;


        private IQueryable<Assignment> GetActiveAssignments() =>
            from assignment in GetAll()
            where assignment.DueTo >= DateTime.Now
            orderby assignment.DueTo
            select assignment;

        private IQueryable<Assignment> GetActiveDoneAssignments() =>
            from assignment in GetActiveAssignments()
            join sa in _context.StudentAssignments on assignment.Id equals sa.AssignmentId
            join student in _context.Students on sa.StudentId equals student.Id
            select assignment;

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Assignment>> Get() => Ok(GetAll());

        [HttpGet("Active")]
        public ActionResult<IEnumerable<Assignment>> GetActive()
        {
            return Ok(GetActiveAssignments());
        }

        [HttpGet("Active/Done")]
        public ActionResult<IEnumerable<Assignment>> GetDone() => Ok(GetActiveDoneAssignments());

        [HttpGet("Active/NotDone")]
        public ActionResult<IEnumerable<Assignment>> GetNotDone() =>
            Ok(GetActiveAssignments().Except(GetActiveDoneAssignments()));

        [HttpGet("Inactive")]
        public ActionResult<IEnumerable<Assignment>> GetInactive()
        {
            var assignments = from assignment in GetAll()
                where assignment.DueTo < DateTime.Now
                orderby assignment.DueTo
                select assignment;

            return Ok(assignments);
        }

        // GET api/values/5        
        [HttpGet("{id}")]
        public async Task<ActionResult<Assignment>> GetAsync(int id)
        {
            var assignment = await GetAll().SingleOrDefaultAsync(a => a.Id == id);
            if (assignment is null) return Unauthorized();
            return assignment;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Assignment assignment)
        {
            if (!ModelState.IsValid) return BadRequest();

            var studentId =
                (await _context.Students.SingleOrDefaultAsync(student => student.User.UserName == User.Identity.Name))?.Id;

            if (studentId is null) return BadRequest();

            assignment.StudentId = studentId.Value;
            await _context.Assignments.AddAsync(assignment);
            await _context.SaveChangesAsync();
            return Ok(assignment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student =
                await _context.Students.SingleOrDefaultAsync(stud => stud.User.UserName == User.Identity.Name);

            if (student is null) return BadRequest();

            var assignment = await _context.Assignments.SingleOrDefaultAsync(a => a.Id == id);

            if (assignment is null) return BadRequest();

            if (assignment.StudentId != student.Id) return BadRequest();

            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Assignment assignment)
        {
            if (!ModelState.IsValid) return BadRequest();
            
            if (assignment is null) return BadRequest();
            
            if (id != assignment.Id) return BadRequest();

            var student =
                await _context.Students.SingleOrDefaultAsync(stud => stud.User.UserName == User.Identity.Name);

            if (student is null) return BadRequest();

            if (assignment.StudentId != student.Id) return BadRequest();


            _context.Entry(assignment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();

        }

        [HttpPost("Done")]
        public async Task<IActionResult> SetToDone([FromBody] int id)
        {
            var student = await _context.Students.SingleOrDefaultAsync(s => s.User.UserName == User.Identity.Name);
            if (student is null) return BadRequest();
            var assignment = await _context.Assignments.SingleOrDefaultAsync(a => a.Id == id);
            if (assignment is null) return BadRequest();
            await _context.StudentAssignments.AddAsync(new StudentAssignment
            {
                StudentId = student.Id,
                AssignmentId = id
            });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}