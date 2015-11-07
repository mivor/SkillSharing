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
            
        }

        public void Put([FromBody] PostDto post)
        {
            
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
                Content = model.Post.Content,
                Name = model.Post.Name,
                IsTodo = model.IsTodo,
                IsDone = model.IsDone
            };
        }
    }
}