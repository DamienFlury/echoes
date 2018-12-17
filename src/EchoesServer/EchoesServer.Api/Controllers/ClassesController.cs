using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchoesServer.Api.Data;
using EchoesServer.Api.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;

namespace EchoesServer.Api.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly SchoolContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClassesController (SchoolContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET api/values
        [HttpGet]
        [Authorize (AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<Class>>> Get ()
        {
            //            return Ok(_context.Classes.Select(cls => new ClassDTO(cls)));
            //            return Ok(_context.Classes.Include(cls => cls.StudentClasses).ThenInclude(sc => sc.Student).Select(cls => new
            //            {
            //                cls.Id,
            //                cls.Name,
            //                Students = cls.StudentClasses.Select(sc => sc.Student).Select(student => new
            //                {
            //                    student.Id,
            //                    student.FirstName,
            //                    student.LastName
            //                })
            //            }));
            // return Ok (_context.Classes.Where (cls => cls.StudentClasses.Select (sc => sc.Student).Any (student => student.User.UserName == User.Identity.Name)));
            return Ok(new string[] {"lol"});
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public ActionResult<Class> Get (int id) => _context.Classes.Find (id);
    }
}