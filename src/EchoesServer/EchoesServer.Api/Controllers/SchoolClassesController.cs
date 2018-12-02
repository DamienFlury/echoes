using System.Collections.Generic;
using EchoesServer.Api.Data;
using EchoesServer.Api.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EchoesServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolClassesController : ControllerBase
    {
        private readonly SchoolContext _context;

        public SchoolClassesController(SchoolContext context) => _context = context;

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<SchoolClass>> Get() => _context.SchoolClasses;

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<SchoolClass> Get(int id) => _context.SchoolClasses.Find(id);
    }
}