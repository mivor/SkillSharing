using System;
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

        [Route("api/channels/subscribed")]
        public IEnumerable<ChannelDto> GetSubscribed()
        {
            return _service.GetAllSubscribed(UserSession.UserId).Select(x => new ChannelDto
            {
                Id = x.Id,
                IsRequired = x.IsRequired,
                IsSubscribed = true,
                Name = x.Name
            }).ToList();
        }

        public IEnumerable<ChannelDto> Get()
        {
            var subscribedChannels = new HashSet<Guid>(_service.GetAllSubscribed(UserSession.UserId).Select(x => x.Id));
            return _service.GetAll().Select(x => new ChannelDto
            {
                Id = x.Id,
                IsRequired = x.IsRequired,
                IsSubscribed = subscribedChannels.Contains(x.Id),
                Name = x.Name
            }).ToList();
        }

        public void Post([FromBody] ChannelDto dto)
        {
            if (dto.IsSubscribed)
            {
                _service.Subscribe(dto.Id, UserSession.UserId);
            }
            else
            {
                _service.Unsubscribe(dto.Id, UserSession.UserId);
            }
        }
    }
}