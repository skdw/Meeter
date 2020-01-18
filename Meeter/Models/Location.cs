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

    public class Viewport
    {
        public int Id { get; set; }

        public string NorthEastId { get; set; }
        public virtual Location NorthEast { get; set; }

        public string SouthWestId { get; set; }
        public virtual Location SouthWest { get; set; }
    }

    public class PlaceGeometry
    {
        public int Id { get; set; }
        public string LocationId { get; set; }
        public virtual Location Location { get; set; }

        public int ViewportId { get; set; }
        public virtual Viewport Viewport { get; set; }
    }
}
