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
    public class ClassesController : ApiControllerBase
    {
        public ClassesController(SchoolContext context) : base(context)
        {
        }

        private IQueryable<Class> GetAll() =>
            from cls in Context.Classes
            join sc in Context.StudentClasses on cls.Id equals sc.ClassId
            join student in Context.Students on sc.StudentId equals student.Id
            where student.User.UserName == User.Identity.Name
            select cls;

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Class>> Get() => Ok(GetAll());

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> Get(int id)
        {
            var cls = await GetAll().Include(c => c.Subjects).SingleOrDefaultAsync(c => c.Id == id);
            if (cls is null) return NotFound();
            return cls;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Class cls)
        {
            if (!ModelState.IsValid) return BadRequest();
            var student = await GetCurrentStudentAsync();
            if (student is null) return BadRequest();
            Context.StudentClasses.Add(new StudentClass {Student = student, Class = cls});
            await Context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("leave/{id}")]
        public async Task<ActionResult> LeaveClass(int id)
        {
            var student = await GetCurrentStudentAsync();
            if (student is null) return BadRequest();

            var studClass =
                await Context.StudentClasses.SingleOrDefaultAsync(sc =>
                    sc.StudentId == student.Id && sc.ClassId == id);
            if (studClass is null) return BadRequest();
            Context.StudentClasses.Remove(studClass);
            await Context.SaveChangesAsync();
            if (Context.StudentClasses.Any(sc => sc.ClassId == id)) return Ok();
            Context.Classes.Remove(new Class {Id = id});
            await Context.SaveChangesAsync();
            return Ok();
        }
    }
}
