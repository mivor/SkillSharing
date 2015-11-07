namespace SkillSharing.Dtos
{
    public class ChannelDto : DtoBase
    {
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public bool IsSubscribed { get; set; }
    }
}