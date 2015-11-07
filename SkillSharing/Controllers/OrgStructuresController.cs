using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SkillSharing.Dtos;
using SkillSharing.Service;

namespace SkillSharing.Controllers
{
    public class OrgStructuresController : ApiController
    {
        private readonly OrgStructureService _service;

        public OrgStructuresController()
        {
            _service = new OrgStructureService();
        }

        [Route("orgstructures")]
        public IEnumerable<OrgStructureDto> Get()
        {
            return _service.GetAll(UserSession.UserId).Select(x => new OrgStructureDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}

