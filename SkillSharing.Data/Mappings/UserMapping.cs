using System.Data.Entity.ModelConfiguration;
using SkillSharing.Model;

namespace SkillSharing.Data.Mappings
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
        }
    }
}