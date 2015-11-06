using System.Collections.Generic;

namespace SkillSharing.Model
{
    public class OrgStructure : ModelBase
    {
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Channel> Channels { get; set; } 
    }
}