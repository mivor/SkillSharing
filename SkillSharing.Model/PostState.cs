namespace SkillSharing.Model
{
    public class PostState : ModelBase
    {
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
        public bool IsTodo { get; set; }
        public bool IsDone { get; set; }
        public bool IsHidden { get; set; }
    }
}