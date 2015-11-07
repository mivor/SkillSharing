using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using SkillSharing.Model;

namespace SkillSharing.Data
{
    public class SkillSharingSeed : DropCreateDatabaseIfModelChanges<SkillSharingContext>
    {
        protected override void Seed(SkillSharingContext context)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Razvan",
                LastName = "Rotaru",
                Mail = "razvan.rotaru@accesa.eu"
            };

            var ykc = new Channel
            {
                Id = Guid.NewGuid(), 
                Name = "Yukon"
            };

            var js = new Channel
            {
                Id = Guid.NewGuid(), 
                Name = "JavaScript"
            };

            var cs = new Channel
            {
                Id = Guid.NewGuid(), 
                Name = "C#"
            };

            var sap = new Channel
            {
                Id = Guid.NewGuid(), 
                Name = "SAP"
            };

            var bi = new OrgStructure
            {
                Id = Guid.NewGuid(),
                Name = "Business Integration & Reporting",
            };

            var sm = new OrgStructure
            {
                Id = Guid.NewGuid(),
                Name = "Scientific & Medical"
            };

            var yk = new OrgStructure
            {
                Id = Guid.NewGuid(),
                Name = "Yukon"
            };

            var tc = new OrgStructure
            {
                Id = Guid.NewGuid(),
                Name = "Technical"
            };

            yk.Channels = new List<Channel> { ykc };
            tc.Channels = new List<Channel> { js };
            bi.Channels = new List<Channel> { sap };
            sm.Channels = new List<Channel> { cs };



            var sts = new List<OrgStructure>
            {
                bi, sm, yk, tc
            };

            

            var posts = new List<Post>
            {
                new Post
                {
                    Id = Guid.NewGuid(),
                    Channel = cs,
                    Content = "ROCKS",
                    Name = "working post none",
                    Publisher = user
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Channel = cs,
                    Content = "ROCKS",
                    Name = "working post todo",
                    Publisher = user
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Channel = sap,
                    Content = "inteligence",
                    Name = "sap training done",
                    Publisher = user
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Channel = sap,
                    Content = "inteligence",
                    Name = "sap training todo done",
                    Publisher = user
                }
            };

            var postStates = new List<PostState>
            {
                new PostState
                {
                    Id = Guid.NewGuid(),
                },
                new PostState
                {
                    Id = Guid.NewGuid(),
                    IsTodo = true,
                },
                new PostState
                {
                    Id = Guid.NewGuid(),
                    IsDone = true,

                },
                new PostState
                {
                    Id = Guid.NewGuid(),
                    IsTodo = true,
                    IsDone = true
                }
            };

            for (int i = 0; i < posts.Count; i++)
            {
                posts[i].PostStates = new Collection<PostState> { postStates[i] };
                postStates[i].Post = posts[i];
                postStates[i].User = user;
            }

            sts.ForEach(x => x.Users = new List<User> {user});
            user.Channels = new List<Channel> { cs, js };
            user.OrgStructures = sts;

            context.Users.Add(user);

            context.OrgStructures.AddRange(sts);
            context.Posts.AddRange(posts);
            context.PostStates.AddRange(postStates);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
