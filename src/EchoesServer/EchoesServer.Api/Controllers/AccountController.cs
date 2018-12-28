using System;
using System.Linq;
using System.Threading.Tasks;
using EchoesServer.Api.Data;
using EchoesServer.Api.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EchoesServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SchoolContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SchoolContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] LoginViewModel model)
        {
            // var user = await _userManager.FindByEmailAsync(model.Email);
            // if (!(user is null)) return Conflict("User already exists");

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result != IdentityResult.Success) return BadRequest(result.Errors);

            var student = new Student
            {
                FirstName = user.Email,
                LastName = user.Email,
                User = user
            };

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return Created("User created", new { user.Email });
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Student> Get()
        {
            return Ok(_context.Students.SingleOrDefault(stud => stud.User.UserName == User.Identity.Name));
        }
    }
}