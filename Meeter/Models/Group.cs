using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Meeter.Models
{
    public class Group
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       [Key]
        public int Id { get; set; }

        // public List<int> Members { get; set; } <- many to many relation, data stored in 'GroupMember' junction table

        //  public int CreatorId { get; set; }
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        public string Creatorid { get; set; }

        public virtual User Creator { get; set; }

        //  public virtual ICollection<GroupMember> Memberships { get; set; }
    }
}
