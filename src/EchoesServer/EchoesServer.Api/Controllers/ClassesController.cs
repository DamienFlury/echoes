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

        private IQueryable<Class> GetAll() => _context.Classes
            .Where(cls => cls.StudentClasses.Select(sc => sc.Student)
                .Any(student => student.User.UserName == User.Identity.Name));

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Class>> Get() => Ok(GetAll());

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> Get(int id)
        {
            var cls = await GetAll().Include(c => c.Assignments).SingleOrDefaultAsync(c => c.Id == id);
            if (cls is null) return Unauthorized();
            return cls;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Class cls)
        {
            var student = await _context.Students.SingleOrDefaultAsync(std => std.User.UserName == User.Identity.Name);
            _context.StudentClasses.Add(new StudentClass { Student = student, Class = cls });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}