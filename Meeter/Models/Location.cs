using System;
using System.ComponentModel.DataAnnotations;

namespace Meeter.Models
{
    public class Location
    {
        public string Id { get; set; }

        [Range(-180, 180)]
        public float Lat { get; set; }

        [Range(-90, 90)]
        public float Lng { get; set; }

        public string Address { get; set; }

        public override string ToString() => Address;
    }
}
