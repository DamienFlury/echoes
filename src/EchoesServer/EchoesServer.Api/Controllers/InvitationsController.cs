using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchoesServer.Api.Data;
using EchoesServer.Api.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EchoesServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvitationsController : ApiControllerBase
    {
        public InvitationsController(SchoolContext context) : base(context)
        {
        }

        [HttpPost]
        public async Task<IActionResult> InviteAsync(InvitationByEmail invitation)
        {
            if (!ModelState.IsValid) return BadRequest();

            var student = await GetCurrentStudentAsync();
            if (student is null) return BadRequest();

            var isMember = await Context.StudentClasses
                .AnyAsync(sc => sc.ClassId == invitation.ClassId && sc.StudentId == student.Id);
            if (!isMember) return Forbid();

            var invitedStudent = await Context.Students.SingleOrDefaultAsync(s => s.User.Email == invitation.Email);
            if (invitedStudent is null) return BadRequest();

            Context.Invitations.Add(new Invitation
            {
                ClassId = invitation.ClassId,
                StudentId = invitedStudent.Id
            });
            await Context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invitation>>> Get()
        {
            var student = await GetCurrentStudentAsync();
            if (student is null) return BadRequest();

            var invitations = from invitation in Context.Invitations
                where invitation.StudentId == student.Id
                select invitation.Class;

            return Ok(invitations);
        }

        [HttpPost("accept/{id}")]
        public async Task<ActionResult<IEnumerable<Invitation>>> Accept(int id)
        {
            var student = await GetCurrentStudentAsync();
            if (student is null) return BadRequest();

            var invitationToRemove =
                await Context.Invitations.SingleOrDefaultAsync(inv => inv.ClassId == id && inv.StudentId == student.Id);
            if (invitationToRemove is null) return BadRequest();

            Context.StudentClasses.Add(new StudentClass
            {
                StudentId = student.Id,
                ClassId = id
            });
            Context.Invitations.Remove(invitationToRemove);

            await Context.SaveChangesAsync();
            return await Get();
        }
    }
}
