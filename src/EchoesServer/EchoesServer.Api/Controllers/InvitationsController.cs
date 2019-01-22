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
    [Authorize]
    public class InvitationsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public InvitationsController(SchoolContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> InviteAsync(InvitationByEmail invitation)
        {
            if (!ModelState.IsValid) return BadRequest();

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
        public ActionResult<IEnumerable<Invitation>> Get()
        {
            var student = _context.Students.SingleOrDefault(stud => stud.User.UserName == User.Identity.Name);
            if (student is null) return BadRequest();

            var invitations = from invitation in _context.Invitations
                where invitation.StudentId == student.Id
                select invitation.Class;

            return Ok(invitations);
        }

        [HttpGet("accept/{id}")]
        public ActionResult<IEnumerable<Invitation>> Accept(int id)
        {
            var student = _context.Students.SingleOrDefault(stud => stud.User.UserName == User.Identity.Name);
            if (student is null) return BadRequest();

            _context.StudentClasses.Add(new StudentClass
            {
                StudentId = student.Id,
                ClassId = id
            });

            var invitationToRemove = _context.Invitations.SingleOrDefault(inv => inv.ClassId == id && inv.StudentId == student.Id);
            if (invitationToRemove is null) return BadRequest();
            _context.Invitations.Remove(invitationToRemove);

            _context.SaveChanges();
            return Get();
        }
    }
}