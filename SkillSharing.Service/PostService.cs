using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SkillSharing.Data;
using SkillSharing.Model;

namespace SkillSharing.Service
{
    public class PostService
    {
        public IEnumerable<Post> GetAll(Guid userId)
        {
            using (var ctx = new SkillSharingContext())
            {
                return ctx.Users.Single(x => x.Id == userId).Channels.SelectMany(x => x.Posts);
            }
        }

        public IEnumerable<PostState> GetAllTodo(Guid userId)
        {
            using (var ctx = new SkillSharingContext())
            {
                return ctx.PostStates.Where(x => x.IsTodo && x.User.Id == userId).Include(x => x.Post).ToList();
            }
        }

        public IEnumerable<Post> GetByChannel(Guid channelId)
        {
            using (var ctx = new SkillSharingContext())
            {
                return ctx.Channels.Single(x => x.Id == channelId).Posts.ToList();
            }
        }

        public IEnumerable<Post> GetByOrgStructure(Guid orgStructureId)
        {
            using (var ctx = new SkillSharingContext())
            {
                return ctx.Channels.Single(x => x.Id == orgStructureId).Posts.ToList();
            }
        }
    }
}