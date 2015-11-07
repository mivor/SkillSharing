using System.Collections.Generic;

namespace SkillSharing.Model
{
    public class Channel : ModelBase
    {
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<OrgStructure> OrgStructures { get; set; } 
    }
}