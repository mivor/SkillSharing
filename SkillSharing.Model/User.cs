using System.Collections.Generic;

namespace SkillSharing.Model
{
    public class User : ModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public virtual ICollection<Channel> Channels { get; set; }
        public virtual ICollection<OrgStructure> OrgStructures { get; set; } 
    }
}