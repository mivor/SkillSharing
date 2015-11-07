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
        public IEnumerable<PostState> GetAll(Guid userId)
        {
            using (var ctx = new SkillSharingContext())
            {
                return ctx.Users.Single(x => x.Id == userId).Channels.SelectMany(x => x.Posts).Select(x => GetPostState(x, userId)).ToList();
            }
        }

        public IEnumerable<PostState> GetAllTodo(Guid userId)
        {
            using (var ctx = new SkillSharingContext())
            {
                return ctx.PostStates.Where(x => x.IsTodo && x.User.Id == userId).Include(x => x.Post).ToList();
            }
        }

        public IEnumerable<PostState> GetByChannel(Guid channelId, Guid userId)
        {
            using (var ctx = new SkillSharingContext())
            {
                return ctx.Channels.Single(x => x.Id == channelId).Posts.Select(x => GetPostState(x, userId)).ToList();
            }
        }

        public IEnumerable<PostState> GetByOrgStructure(Guid orgStructureId, Guid userId)
        {
            using (var ctx = new SkillSharingContext())
            {
                return ctx.OrgStructures.Single(x => x.Id == orgStructureId).Channels.SelectMany(x => x.Posts).Select(x => GetPostState(x, userId)).ToList();
            }
        }

        public void UpdateState(PostState postState)
        {
            using (var ctx = new SkillSharingContext())
            {
                var state = ctx.PostStates.SingleOrDefault(x => x.Id == postState.Id && x.UserId == postState.UserId);
                if (state == null)
                {
                    state = new PostState
                    {
                        Id = Guid.NewGuid(),
                        PostId = postState.PostId,
                        UserId = postState.UserId
                    };
                    ctx.PostStates.Add(state);
                }
                
                state.IsTodo = postState.IsTodo;
                state.IsDone = postState.IsDone;
                state.IsHidden = postState.IsHidden;

                ctx.SaveChanges();
            }
        }

        public PostState Create(string name, string content, bool isSticky, Guid userId, Guid channelId)
        {
            var post = new Post
            {
                Id = Guid.NewGuid(),
                Name = name,
                IsSticky = isSticky,
                Content = content,
                Timestamp = DateTime.Now,
                PublisherId = userId,
                ChannelId = channelId
            };

            using (var ctx = new SkillSharingContext())
            {
                ctx.Posts.Add(post);
                ctx.SaveChanges();
                return new PostState
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Post = post,
                };
            }
        }

        private PostState GetPostState(Post post, Guid userId)
        {
            var state = post.PostStates.SingleOrDefault(s => s.User.Id == userId);
            return state ?? new PostState
            {
                Id = Guid.NewGuid(),
                User = new User { Id = userId },
                Post = post
            };
        }
    }
}