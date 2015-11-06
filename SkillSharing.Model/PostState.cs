namespace SkillSharing.Model
{
    public class PostState : ModelBase
    {
        public User User { get; set; }
        public Post Post { get; set; }
        public bool IsTodo { get; set; }
        public bool IsDone { get; set; }
    }
}