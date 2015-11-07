using System.Data.Entity.ModelConfiguration;
using SkillSharing.Model;

namespace SkillSharing.Data
{
    public class PostMapping : EntityTypeConfiguration<Post>
    {
        public PostMapping()
        {
            Property(x => x.ChannelId).HasColumnName("Channel_Id");
            HasRequired(x => x.Channel).WithMany(x => x.Posts).HasForeignKey(y => y.ChannelId).WillCascadeOnDelete(false);

            Property(x => x.PublisherId).HasColumnName("Publisher_Id");
            HasRequired(x => x.Publisher).WithMany().HasForeignKey(y => y.PublisherId).WillCascadeOnDelete(false);
        }
    }
}