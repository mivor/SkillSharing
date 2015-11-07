using System;
using System.Collections.Generic;
using System.Linq;
using SkillSharing.Data;
using SkillSharing.Model;

namespace SkillSharing.Service
{
    public class ChannelService
    {
        public IEnumerable<Channel> GetAllSubscribed(Guid userId)
        {
            using (var ctx = new SkillSharingContext())
            {
                return ctx.Users.Single(x => x.Id == userId).Channels.ToList();
            }
        }

        public IEnumerable<Channel> GetAll()
        {
            using (var ctx = new SkillSharingContext())
            {
                return ctx.Channels.ToList();
            }
        }
    }
}