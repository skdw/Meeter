using System;
using System.Collections.Generic;

namespace Meeter.Models
{
    public class Group
    {
        public int Id { get; set; }

        public List<int> Members { get; set; }

        public int CreatorId { get; set; }
    }
}
