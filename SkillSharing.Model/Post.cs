using System;
using System.Collections.Generic;

namespace SkillSharing.Model
{
    public class Post : ModelBase
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsSticky { get; set; }

        public Guid PublisherId { get; set; }
        public virtual User Publisher { get; set; }

        public Guid ChannelId { get; set; }
        public virtual Channel Channel { get; set; }

        public virtual ICollection<PostState> PostStates { get; set; } 
    }
}