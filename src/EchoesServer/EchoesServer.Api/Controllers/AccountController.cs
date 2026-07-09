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
    public class AccountController : ApiControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SchoolContext context, UserManager<ApplicationUser> userManager) : base(context)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

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

            await Context.Students.AddAsync(student);

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                await _userManager.DeleteAsync(user);
                return StatusCode(500, "Failed to create student record.");
            }

            return Created("User created", new { user.Email });
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Student>> Get()
        {
            return Ok(await GetCurrentStudentAsync());
        }
    }
}