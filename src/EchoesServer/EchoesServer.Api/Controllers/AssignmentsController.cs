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

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Assignment>> Get() => Ok(GetAll());

        [HttpGet("Active")]
        public ActionResult<IEnumerable<Assignment>> GetActive()
        {
            return Ok(GetActiveAssignments());
        }

        [HttpGet("Active/Done")]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetDone()
        {
            var student = await _context.Students.SingleOrDefaultAsync(s => s.User.UserName == User.Identity.Name);
            if (student is null) return BadRequest();

            var assignments = from assignment in GetActiveAssignments()
                join sa in _context.StudentAssignments on assignment.Id equals sa.AssignmentId
                join stud in _context.Students on sa.StudentId equals stud.Id
                select assignment;

            return Ok(assignments);
            //GetActiveAssignments()
            //.Where(assignment => _context.StudentAssignments
            //    .Any(sa => sa.AssignmentId == assignment.Id && sa.StudentId == student.Id)));
        }

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
            // var classId = assignment.ClassId;
            // if (classId == 0) return BadRequest ();
            // var student = await _context.Students.SingleOrDefaultAsync(stud => stud.User.UserName == User.Identity.Name);
            // if(!student.StudentClasses.Any(sc => sc.StudentId == student.Id && sc.ClassId == classId)) return BadRequest();
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