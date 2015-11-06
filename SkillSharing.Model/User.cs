using System;
using System.Collections.Generic;

namespace SkillSharing.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Tag> Tags { get; set; } 
    }
}