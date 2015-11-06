using System.Data.Entity;
using SkillSharing.Model;

namespace SkillSharing.Data
{
    public class SkillSharingDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public SkillSharingDataContext() : base("SkillSharing")
        {
            
        }


    }
}