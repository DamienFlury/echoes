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
    public class AssignmentsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public AssignmentsController(SchoolContext context) => _context = context;

        // GET api/values
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<IEnumerable<Assignment>> Get()
        {
            return Ok(_context.Assignments.Where(assignment
                => assignment.Class.StudentClasses.Select(sc => sc.Student).Any(student => student.User.UserName == User.Identity.Name)));
        }

        [HttpGet("Active")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<IEnumerable<Assignment>> GetActive()
        {
            return Ok(_context.Assignments.Where(assignment
                => assignment.Class.StudentClasses.Select(sc => sc.Student).Any(student => student.User.UserName == User.Identity.Name) && assignment.DueTo >= DateTime.Now).OrderBy(assignment => assignment.DueTo));
        }

        [HttpGet("Inactive")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<IEnumerable<Assignment>> GetInactive()
        {
            return Ok(_context.Assignments.Where(assignment
                => assignment.Class.StudentClasses.Select(sc => sc.Student).Any(student => student.User.UserName == User.Identity.Name) && assignment.DueTo < DateTime.Now).OrderBy(assignment => assignment.DueTo));
        }

        // GET api/values/5        
        [HttpGet("{id}")]
        public ActionResult<Assignment> Get(int id) => _context.Assignments.Find(id);

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post([FromBody] Assignment assignment)
        {
            // var classId = assignment.ClassId;
            // if (classId == 0) return BadRequest ();
            // var student = await _context.Students.SingleOrDefaultAsync(stud => stud.User.UserName == User.Identity.Name);
            // if(!student.StudentClasses.Any(sc => sc.StudentId == student.Id && sc.ClassId == classId)) return BadRequest();
            await _context.Assignments.AddAsync(assignment);
            await _context.SaveChangesAsync();
            return Ok(assignment);
        }
    }
}