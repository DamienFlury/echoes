using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchoesServer.Api.Data;
using EchoesServer.Api.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EchoesServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitationsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public InvitationsController(SchoolContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> InviteAsync(InvitationByEmail invitation)
        {
            var invitedStudent = _context.Students.SingleOrDefault(student => student.User.Email == invitation.Email);
            if (invitedStudent is null) return BadRequest();

            var studentId = invitedStudent.Id;

            _context.Invitations.Add(new Invitation
            {
                ClassId = invitation.ClassId,
                StudentId = studentId
            });
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<IEnumerable<Invitation>> Get()
        {
            var student = _context.Students.SingleOrDefault(stud => stud.User.UserName == User.Identity.Name);
            if (student is null) return BadRequest();

            return Ok(_context.Invitations.Where(inv => inv.StudentId == student.Id).Include(inv => inv.Class)
                .Select(inv => inv.Class));
        }
    }
}