using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SkillSharing.Dtos;
using SkillSharing.Model;
using SkillSharing.Service;

namespace SkillSharing.Controllers
{
    public class PostsController : ApiController
    {
        private readonly PostService _service;

        public PostsController()
        {
            _service = new PostService();
        }

        public IEnumerable<PostDto> Get()
        {
            return _service.GetAll(UserSession.UserId).Select(AdaptModelToDto).ToList();
        }

        public void Post([FromBody] PostDto post)
        {
            var state = new PostState
            {
                Id = post.StateId,
                IsDone = post.IsDone,
                IsTodo = post.IsTodo,
                IsHidden = post.IsHidden,
                UserId = UserSession.UserId,
                PostId = post.Id
            };
            _service.UpdateState(state);
        }

        public PostDto Put([FromBody] PostDto dto)
        {
            var result = _service.Create(dto.Name, dto.Content, dto.IsSticky, UserSession.UserId, dto.ChannelId);
            return AdaptModelToDto(result);
        }

        [Route("api/posts/todo")]
        public IEnumerable<PostDto> GetTodo()
        {
            return _service.GetAllTodo(UserSession.UserId).Select(AdaptModelToDto).ToList();
        }

        [Route("api/posts/channel/{id}")]
        public IEnumerable<PostDto> GetByChannel(Guid id)
        {
            return _service.GetByChannel(id, UserSession.UserId).Select(AdaptModelToDto).ToList();
        }

        [Route("api/posts/orgstructure/{id}")]
        public IEnumerable<PostDto> GetByOrgStructure(Guid id)
        {
            return _service.GetByOrgStructure(id, UserSession.UserId).Select(AdaptModelToDto).ToList();
        }

        private PostDto AdaptModelToDto(PostState model)
        {
            return new PostDto
            {
                Id = model.Post.Id,
                Name = model.Post.Name,
                Content = model.Post.Content,
                Timestamp = model.Post.Timestamp,
                IsSticky = model.Post.IsSticky,
                StateId = model.Id,
                IsTodo = model.IsTodo,
                IsDone = model.IsDone,
                IsHidden = model.IsHidden,
            };
        }
    }
}