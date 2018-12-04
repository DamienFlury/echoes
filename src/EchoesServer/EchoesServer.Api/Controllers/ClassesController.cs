using System.Collections.Generic;
using System.Linq;
using EchoesServer.Api.Data;
using EchoesServer.Api.Data.DTOs;
using EchoesServer.Api.Data.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<IEnumerable<ClassDTO>> Get() =>
            Ok(_context.Classes.Select(cls => new ClassDTO(cls)));

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Class> Get(int id) => _context.Classes.Find(id);
    }
}