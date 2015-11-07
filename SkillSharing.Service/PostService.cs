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

        public IEnumerable<PostState> GetByChannel(Guid channelId)
        {
            using (var ctx = new SkillSharingContext())
            {
                return ctx.PostStates.Where(x => x.Post.Channel.Id == channelId).Include(x => x.Post).ToList();
            }
        }

        public IEnumerable<PostState> GetByOrgStructure(Guid orgStructureId)
        {
            using (var ctx = new SkillSharingContext())
            {
                return ctx.PostStates.Where(x => x.Post.Channel.OrgStructures.Select(o => o.Id).Contains(orgStructureId)).Include(x => x.Post).ToList();
            }
        }
    }
}