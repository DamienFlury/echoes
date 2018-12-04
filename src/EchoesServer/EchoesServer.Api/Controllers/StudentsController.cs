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
    public class StudentsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context) => _context = context;

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<StudentDTO>> Get() => 
            Ok(_context.Students.Select(student => new StudentDTO(student)));

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id) => _context.Students.Find(id);
    }
}