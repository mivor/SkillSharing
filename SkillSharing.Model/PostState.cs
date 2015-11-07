using System;

namespace SkillSharing.Model
{
    public class PostState : ModelBase
    {
        public bool IsTodo { get; set; }
        public bool IsDone { get; set; }
        public bool IsHidden { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}