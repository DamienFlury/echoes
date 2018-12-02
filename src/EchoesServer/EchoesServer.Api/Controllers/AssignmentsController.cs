using System.Collections.Generic;
using EchoesServer.Api.Data;
using EchoesServer.Api.Data.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<IEnumerable<Assignment>> Get() => _context.Assignments;

        // GET api/values/5        
        [HttpGet("{id}")]
        public ActionResult<Assignment> Get(int id) => _context.Assignments.Find(id);
    }
}