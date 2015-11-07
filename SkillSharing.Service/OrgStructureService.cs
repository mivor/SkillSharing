using System;
using System.Collections.Generic;
using System.Linq;
using SkillSharing.Data;
using SkillSharing.Model;

namespace SkillSharing.Service
{
    public class OrgStructureService
    {
        public IEnumerable<OrgStructure> GetAll(Guid userId)
        {
            using (var ctx = new SkillSharingContext())
            {
                return ctx.Users.Single(x => x.Id == userId).OrgStructures.ToList();
            }
        }
    }
}