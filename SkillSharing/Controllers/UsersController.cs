using System;
using System.Linq;
using System.Web.Http;
using SkillSharing.Data;
using SkillSharing.Dtos;

namespace SkillSharing.Controllers
{
    public class UsersController : ApiController
    {
        [Route("api/users/current")]
        public UserDto GetCurrent()
        {
            using (var ctx = new SkillSharingContext())
            {
                var user = ctx.Users.Single();
                var dto = new UserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Mail = user.Mail
                };
                UserSession.UserId = dto.Id;
                return dto;
            }
        }
    }

    public static class UserSession
    {
        public static Guid UserId { get; set; }
    }
}