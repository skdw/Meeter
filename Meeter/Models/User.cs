using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Meeter.Models
{
    public class User : IdentityUser
    {
        // public string  Id { get; set; }

        //public int IdentityUserId { get; set; } <- one to one relation
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public bool isPesudoUser { get; set; }
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        public string LocationId { get; set; }

        public virtual Location Location { get; set; }

        public string Photo { get; set; }

        //public virtual IdentityUser IdentityUser { get; set; }

        public virtual ICollection<GroupMember> Memberships { get; set; }
        public virtual ICollection<Group> CreatedGroups { get; set; }
    }
}
