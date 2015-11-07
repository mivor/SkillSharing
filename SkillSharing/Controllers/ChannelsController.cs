using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SkillSharing.Dtos;
using SkillSharing.Service;

namespace SkillSharing.Controllers
{
    public class ChannelsController : ApiController
    {
        private readonly ChannelService _service;

        public ChannelsController()
        {
            _service = new ChannelService();
        }

        [Route("channels/subscribed")]
        public IEnumerable<ChannelDto> GetSubscribed()
        {
            return _service.GetAllSubscribed(UserSession.UserId).Select(x => new ChannelDto
            {
                Id = x.Id,
                IsRequired = x.IsRequired,
                Name = x.Name
            }).ToList();
        }

        public IEnumerable<ChannelDto> Get()
        {
            return _service.GetAll().Select(x => new ChannelDto
            {
                Id = x.Id,
                IsRequired = x.IsRequired,
                Name = x.Name
            }).ToList();
        }
    }
}