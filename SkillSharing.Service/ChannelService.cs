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

        public void Subscribe(Guid channelId, Guid userId)
        {
            using (var ctx = new SkillSharingContext())
            {
                var channel = ctx.Channels.Single(x => x.Id == channelId);
                var user = ctx.Users.Single(x => x.Id == userId);

                user.Channels.Add(channel);
                ctx.SaveChanges();
            }
        }

        public void Unsubscribe(Guid channelId, Guid userId)
        {
            using (var ctx = new SkillSharingContext())
            {
                var user = ctx.Users.Single(x => x.Id == userId);
                var channel = user.Channels.SingleOrDefault(x => x.Id == channelId);

                user.Channels.Remove(channel);
                ctx.SaveChanges();
            }
        }
    }
}