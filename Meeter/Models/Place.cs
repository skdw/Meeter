using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Meeter.Models
{
    public class Place
    {
        public string Icon { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public int PriceLevel { get; set; }

        public float Rating { get; set; }

        public string Vicinity { get; set; }

        public string LocationId { get; set; }

        public virtual Location Location { get; set; }

        public bool OpenNow { get; set; }

        public int UserRatingsTotal { get; set; }

        public virtual ICollection<Type> Types { get; set; }
    }
}
