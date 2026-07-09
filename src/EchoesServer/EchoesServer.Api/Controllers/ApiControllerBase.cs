using System.Threading.Tasks;
using EchoesServer.Api.Data;
using EchoesServer.Api.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EchoesServer.Api.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly SchoolContext Context;

        protected ApiControllerBase(SchoolContext context) => Context = context;

        protected Task<Student> GetCurrentStudentAsync() =>
            Context.Students.SingleOrDefaultAsync(s => s.User.UserName == User.Identity.Name);
    }
}
