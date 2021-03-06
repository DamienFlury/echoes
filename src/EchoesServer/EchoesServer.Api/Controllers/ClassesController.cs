using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchoesServer.Api.Data;
using EchoesServer.Api.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Frameworks;

namespace EchoesServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClassesController : ControllerBase
    {
        private readonly SchoolContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClassesController(SchoolContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private IQueryable<Class> GetAll() =>
            from cls in _context.Classes
            join sc in _context.StudentClasses on cls.Id equals sc.ClassId
            join student in _context.Students on sc.StudentId equals student.Id
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
            if (cls is null) return Unauthorized();
            return cls;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Class cls)
        {
            if (!ModelState.IsValid) return BadRequest();
            var student = await _context.Students.SingleOrDefaultAsync(std => std.User.UserName == User.Identity.Name);
            _context.StudentClasses.Add(new StudentClass {Student = student, Class = cls});
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("leave/{id}")]
        public async Task<ActionResult> LeaveClass(int id)
        {
            var student = await _context.Students.SingleOrDefaultAsync(std => std.User.UserName == User.Identity.Name);
            var studClass =
                await _context.StudentClasses.SingleOrDefaultAsync(sc =>
                    sc.StudentId == student.Id && sc.ClassId == id);
            if (studClass is null) return BadRequest();
            _context.StudentClasses.Remove(studClass);
            await _context.SaveChangesAsync();
            if (_context.StudentClasses.Any(sc => sc.ClassId == id)) return Ok();
            _context.Classes.Remove(new Class {Id = id});
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}