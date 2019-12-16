﻿using System;
namespace Meeter.Models
{
    public class Place
    {
        public PlaceGeometry Geometry { get; set; }

        public string Icon { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public PlaceOpeningHours OpeningHours { get; set; }

        public string PlaceId { get; set; }

        public int PriceLevel { get; set; }

        public float Rating { get; set; }

        // public string[] Types { get; set; }

        public string Vicinity { get; set; }
    }

    public struct PlaceOpeningHours
    {
        public bool OpenNow { get; set; }
    }
}
