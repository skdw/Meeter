using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Meeter.Models
{
    public class User : IdentityUser
    {
       // public string  Id { get; set; }

        //public int IdentityUserId { get; set; } <- one to one relation

        public string FirstName { get; set; }

        public string LastName { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public Location Location { get; set; }

        public string Photo { get; set; }

        //public virtual IdentityUser IdentityUser { get; set; }

        public virtual ICollection<GroupMember> Memberships { get; set; }
    }
}
