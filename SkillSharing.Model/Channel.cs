using System.Collections.Generic;

namespace SkillSharing.Model
{
    public class Channel : ModelBase
    {
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<OrgStructure> OrgStructures { get; set; } 
    }
}