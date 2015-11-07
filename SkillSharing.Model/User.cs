using System.Collections.Generic;

namespace SkillSharing.Model
{
    public class User : ModelBase
    {
        private ICollection<Channel> _channels;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }

        public virtual ICollection<Channel> Channels
        {
            get { return _channels ?? (_channels = new List<Channel>()); }
            set { _channels = value; }
        }

        public virtual ICollection<OrgStructure> OrgStructures { get; set; } 
    }
}