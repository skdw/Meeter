using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meeter.Models
{
    public class Group
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Id { get; set; }

       // public List<int> Members { get; set; } <- many to many relation, data stored in 'GroupMember' junction table

        public int CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public virtual ICollection<GroupMember> Members { get; set; }
    }
}
