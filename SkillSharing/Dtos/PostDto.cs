using System;

namespace SkillSharing.Dtos
{
    public class PostDto : DtoBase
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsSticky { get; set; }


        public bool IsTodo { get; set; }
        public bool IsDone { get; set; }
        public bool IsHidden { get; set; }
    }
}