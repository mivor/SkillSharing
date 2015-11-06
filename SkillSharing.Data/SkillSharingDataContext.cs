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

//            modelBuilder.Entity<OrgStructure>()
//                   .HasMany<User>(s => s.Users)
//                   .WithMany(c => c.OrgStructures)
//                   .Map(x =>
//                   {
//                       x.MapLeftKey("OrgStructure_Id");
//                       x.MapRightKey("User_Id");
//                       x.ToTable("OrgStructuresUsers");
//                   });
//
//            modelBuilder.Entity<OrgStructure>()
//                   .HasMany<Channel>(s => s.Channels)
//                   .WithMany(c => c.OrgStructures)
//                   .Map(x =>
//                   {
//                       x.MapLeftKey("OrgStructure_Id");
//                       x.MapRightKey("Channel_Id");
//                       x.ToTable("OrgStructuresChannels");
//                   });
        }
    }
}