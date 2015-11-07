using System.Data.Entity.ModelConfiguration;
using SkillSharing.Model;

namespace SkillSharing.Data
{
    public class PostStateMapping : EntityTypeConfiguration<PostState>
    {
        public PostStateMapping()
        {
            Property(x => x.UserId).HasColumnName("User_Id");
            HasRequired(x => x.User).WithMany().HasForeignKey(y => y.UserId).WillCascadeOnDelete(false);

            Property(x => x.PostId).HasColumnName("Post_Id");
            HasRequired(x => x.Post).WithMany().HasForeignKey(y => y.PostId).WillCascadeOnDelete(false);
        }
    }
}