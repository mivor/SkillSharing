namespace SkillSharing.Dtos
{
    public class PostDto : DtoBase
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public bool IsTodo { get; set; }
        public bool IsDone { get; set; }
    }
}