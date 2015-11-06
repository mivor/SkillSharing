using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using SkillSharing.Model;

namespace SkillSharing.Data
{
    public class SkillSharingSeed : DropCreateDatabaseIfModelChanges<SkillSharingContext>
    {
        public SkillSharingSeed()
        {
        }

        protected override void Seed(SkillSharingContext context)
        {
            var channel = new Channel {Id = Guid.NewGuid(), Name = "News"};
            var user = new User {Id = Guid.NewGuid(), Mail = "a@a.com"};
            context.OrgStructures.Add(new OrgStructure
            {
                Id = Guid.NewGuid(),
                Name = "CC",
                Channels = new Collection<Channel>
                {
                   channel
                },
                Users = new Collection<User>
                {
                    user
                }
            });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}