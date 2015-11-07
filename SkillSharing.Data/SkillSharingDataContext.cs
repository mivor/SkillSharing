using System.Data.Entity;
using SkillSharing.Model;

namespace SkillSharing.Data
{
    public class SkillSharingContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<OrgStructure> OrgStructures { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostState> PostStates { get; set; } 

        public SkillSharingContext() : base("name=SkillSharing")
        {
            Database.SetInitializer(new SkillSharingSeed());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new PostMapping());
            modelBuilder.Configurations.Add(new PostStateMapping());
        }
    }
}