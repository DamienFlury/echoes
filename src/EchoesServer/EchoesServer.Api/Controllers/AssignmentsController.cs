using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchoesServer.Api.Data;
using EchoesServer.Api.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EchoesServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AssignmentsController : ApiControllerBase
    {
        public AssignmentsController(SchoolContext context) : base(context)
        {
        }

        private IQueryable<Assignment> GetAll() =>
            from assignment in Context.Assignments
            join subject in Context.Subjects on assignment.SubjectId equals subject.Id
            join cls in Context.Classes on subject.ClassId equals cls.Id
            join sc in Context.StudentClasses on cls.Id equals sc.ClassId
            join student in Context.Students on sc.StudentId equals student.Id
            where student.User.UserName == User.Identity.Name
            select assignment;


        private IQueryable<Assignment> GetActiveAssignments() =>
            from assignment in GetAll()
            where assignment.DueTo >= DateTime.Now
            orderby assignment.DueTo
            select assignment;

        private IQueryable<Assignment> GetActiveDoneAssignments() =>
            from assignment in GetActiveAssignments()
            join sa in Context.StudentAssignments on assignment.Id equals sa.AssignmentId
            join student in Context.Students on sa.StudentId equals student.Id
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
            if (assignment is null) return NotFound();
            return assignment;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Assignment assignment)
        {
            if (!ModelState.IsValid) return BadRequest();

            var student = await GetCurrentStudentAsync();
            if (student is null) return BadRequest();

            assignment.StudentId = student.Id;
            await Context.Assignments.AddAsync(assignment);
            await Context.SaveChangesAsync();
            return Ok(assignment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await GetCurrentStudentAsync();
            if (student is null) return BadRequest();

            var assignment = await Context.Assignments.SingleOrDefaultAsync(a => a.Id == id);
            if (assignment is null) return BadRequest();

            if (assignment.StudentId != student.Id) return BadRequest();

            Context.Assignments.Remove(assignment);
            await Context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Assignment assignment)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (assignment is null) return BadRequest();

            if (id != assignment.Id) return BadRequest();

            var student = await GetCurrentStudentAsync();
            if (student is null) return BadRequest();

            // Load the tracked entity ourselves rather than trusting the client-supplied
            // StudentId/State for authorization - the request body is attacker-controlled.
            var existing = await GetAll().SingleOrDefaultAsync(a => a.Id == id);
            if (existing is null) return NotFound();
            if (existing.StudentId != student.Id) return Forbid();

            existing.Title = assignment.Title;
            existing.Description = assignment.Description;
            existing.DueTo = assignment.DueTo;
            existing.SubjectId = assignment.SubjectId;

            await Context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("Done")]
        public async Task<IActionResult> SetToDone([FromBody] int id)
        {
            var student = await GetCurrentStudentAsync();
            if (student is null) return BadRequest();

            var assignment = await GetAll().SingleOrDefaultAsync(a => a.Id == id);
            if (assignment is null) return BadRequest();

            var alreadyDone = await Context.StudentAssignments
                .AnyAsync(sa => sa.StudentId == student.Id && sa.AssignmentId == id);
            if (alreadyDone) return Ok();

            await Context.StudentAssignments.AddAsync(new StudentAssignment
            {
                StudentId = student.Id,
                AssignmentId = id
            });
            await Context.SaveChangesAsync();
            return Ok();
        }
    }
}
