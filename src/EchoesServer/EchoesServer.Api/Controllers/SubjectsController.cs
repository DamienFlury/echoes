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
    public class SubjectsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public SubjectsController(SchoolContext context) => _context = context;

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Subject>> Get() => Ok(_context.Subjects);


        // GET api/values/5        
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetAsync(int id)
        {
            var subject = await _context.Subjects.Include(subj => subj.Assignments).SingleOrDefaultAsync(a => a.Id == id);
            if (subject is null) return Unauthorized();
            return subject;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Subject subject)
        {
            if (!ModelState.IsValid) return BadRequest();

            var studentId =
                (await _context.Students.SingleOrDefaultAsync(student => student.User.UserName == User.Identity.Name))?.Id;

            if (studentId is null) return BadRequest();

            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
            return Ok(subject);
        }

    }
}