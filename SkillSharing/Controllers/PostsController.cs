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

        public IEnumerable<Post> Get()
        {
            return _service.GetAll(UserSession.UserId);
        }

        [Route("posts/todo")]
        public IEnumerable<PostDto> GetTodo()
        {
            return _service.GetAllTodo(UserSession.UserId).Select(x => new PostDto
            {
                Id = x.Post.Id,
                Content = x.Post.Content,
                Name = x.Post.Name,
                IsTodo = x.IsTodo,
                IsDone = x.IsDone
            }).ToList();
        }

        [Route("posts/channel/{id}")]
        public IEnumerable<PostDto> GetByChannel(Guid id)
        {
            return _service.GetByChannel(id).Select(x => new PostDto
            {
                Id = x.Post.Id,
                Content = x.Post.Content,
                Name = x.Post.Name,
                IsTodo = x.IsTodo,
                IsDone = x.IsDone
            }).ToList();
        }

        [Route("posts/orgstructure/{id}")]
        public IEnumerable<PostDto> GetByOrgStructure(Guid id)
        {
            return _service.GetByChannel(id).Select(x => new PostDto
            {
                Id = x.Post.Id,
                Content = x.Post.Content,
                Name = x.Post.Name,
                IsTodo = x.IsTodo,
                IsDone = x.IsDone
            }).ToList();
        }
    }
}