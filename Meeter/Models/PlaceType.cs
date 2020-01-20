using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meeter.Models
{
    public class PlaceType
    {
        public int Id { get; set; }

        public string PlaceId { get; set; }

        public virtual Place Place { get; set; }

        public int TypeId { get; set; }
        public virtual Type Type { get; set; }
    }
}
