using System.Collections.Generic;
using System.Linq;
using EchoesServer.Api.Data;
using EchoesServer.Api.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EchoesServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly SchoolContext _context;

        public ClassesController(SchoolContext context) => _context = context;

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Class>> Get() => _context.Classes;

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Class> Get(int id) => _context.Classes.Find(id);
    }
}