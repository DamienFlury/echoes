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
    public class SubjectsController : ApiControllerBase
    {
        public SubjectsController(SchoolContext context) : base(context)
        {
        }

        private IQueryable<Subject> GetAll() =>
            from subject in Context.Subjects
            join sc in Context.StudentClasses on subject.ClassId equals sc.ClassId
            join student in Context.Students on sc.StudentId equals student.Id
            where student.User.UserName == User.Identity.Name
            select subject;

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Subject>> Get() => Ok(GetAll());

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetAsync(int id)
        {
            var subject = await GetAll().Include(subj => subj.Assignments).SingleOrDefaultAsync(a => a.Id == id);
            if (subject is null) return NotFound();
            return subject;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Subject subject)
        {
            if (!ModelState.IsValid) return BadRequest();

            var student = await GetCurrentStudentAsync();
            if (student is null) return BadRequest();

            var isMember = await Context.StudentClasses
                .AnyAsync(sc => sc.ClassId == subject.ClassId && sc.StudentId == student.Id);
            if (!isMember) return Forbid();

            await Context.Subjects.AddAsync(subject);
            await Context.SaveChangesAsync();
            return Ok(subject);
        }
    }
}
