using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Meeter.Models
{
    public class User : IdentityUser
    {
        public bool isPesudoUser { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string LocationId { get; set; }

        public virtual Location Location { get; set; }

        public string Photo { get; set; }

        public virtual ICollection<GroupMember> Memberships { get; set; }
        public virtual ICollection<Group> CreatedGroups { get; set; }

        public string FullName { get => FirstName + " " + LastName; }

        public override string ToString() => FullName;
    }
}
