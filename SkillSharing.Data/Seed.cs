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

            var boarding = new Channel
            {
                Id = Guid.NewGuid(),
                Name = "Onboarding",
                IsRequired = true
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

            yk.Channels = new List<Channel> { ykc, boarding };
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
                    Content = "See at MSDN",
                    Name = "C# 7 proposal",
                    Publisher = user
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Channel = cs,
                    Content = "https://github.com/dotnet/roslyn/issues/206",
                    Name = "Patten matching proposal",
                    Publisher = user
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Channel = js,
                    Content = "You can get it from the company library",
                    Name = "Read the Good parts",
                    Publisher = user,
                    IsSticky = true
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Channel = sap,
                    Content = "Try German classes",
                    Name = "Improve communication skills",
                    Publisher = user,
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Channel = ykc,
                    Content = "There will be no internet on Friday after 2 am",
                    Name = "General announcement",
                    Publisher = user
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Channel = boarding,
                    Name = "Socialize",
                    Content = "Go out to lunch with at least 3 colleagues",
                    Publisher = user
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Channel = boarding,
                    Name = "Kitchen workflow",
                    Content = "Read the kitchen workflow",
                    Publisher = user
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Channel = boarding,
                    Name = "AIMA",
                    Content = "Learn how to use AIMA",
                    Publisher = user,
                    IsSticky = true
                }
            };

            var postStates = new List<PostState>();

            context.Users.Add(user);

            for (int i = 0; i < posts.Count; i++)
            {
                var state = new PostState
                {
                    Id = Guid.NewGuid(),
                    Post = posts[i],
                    User = user
                };
                postStates.Add(state);
                posts[i].PostStates = new Collection<PostState> { postStates[i] };
                posts[i].Timestamp = DateTime.Now;
            }

            foreach (var postState in postStates.Take(2))
            {
                postState.IsTodo = true;
            }
            sts.ForEach(x => x.Users = new List<User> {user});
            user.Channels = new List<Channel> { cs, js };
            user.OrgStructures = sts;

            context.OrgStructures.AddRange(sts);
            context.Posts.AddRange(posts);
            context.PostStates.AddRange(postStates);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
