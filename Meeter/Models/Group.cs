using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Meeter.Models
{
    public class Group
    {
       // [Key]
        public int Id { get; set; }

        // public List<int> Members { get; set; } <- many to many relation, data stored in 'GroupMember' junction table

        //  public int CreatorId { get; set; }
       
        public string Name { get; set; }
        public string Creatorid { get; set; }
        //public string CreatorName { get; set; }

       
        public virtual User Creator { get; set; }

        public virtual ICollection<GroupMember> Memberships { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
