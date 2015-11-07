using System.Collections.Generic;

namespace SkillSharing.Model
{
    public class Post : ModelBase
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public User Publisher { get; set; }
        public Channel Channel { get; set; }
        public virtual ICollection<PostState> PostStates { get; set; } 
    }
}