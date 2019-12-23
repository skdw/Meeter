using System;
namespace Meeter.Models
{
    public struct Location
    {
        public float Lat { get; set; }

        public float Lng { get; set; }
    }

    public struct Viewport
    {
        public Location NorthEast { get; set; }

        public Location SouthWest { get; set; }
    }

    public struct PlaceGeometry
    {
        public Location Location { get; set; }

        public Viewport Viewport { get; set; }
    }
}
