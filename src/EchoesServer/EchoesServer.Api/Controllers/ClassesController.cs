using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchoesServer.Api.Data;
using EchoesServer.Api.Data.DTOs;
using EchoesServer.Api.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;

namespace EchoesServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly SchoolContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClassesController(SchoolContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassDTO>>> Get()
        {
            var user = await _userManager.FindByEmailAsync("test@test.com");
            if (user is null)
            {
                user = new ApplicationUser
                {
                    Email = "test@test.com",
                    UserName = "test@test.com"
                };

                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if (result != IdentityResult.Success) throw new InvalidOperationException();
            }

            return Ok(_context.Classes.Select(cls => new ClassDTO(cls)));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Class> Get(int id) => _context.Classes.Find(id);
    }
}