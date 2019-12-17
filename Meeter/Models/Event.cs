using System;
using System.Collections.Generic;
using System.Linq;

namespace Meeter.Models
{
    public class Event
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        //public List<int> Preferences { get; set; } // ids of UserPreference objects

        public int PlaceId { get; set; }

        public DateTime DateTime { get; set; }

        public virtual ICollection<UserPreference> Preferences { get; set; }

        public virtual Group Group { get; set; }

        public virtual Place Place { get; set; }



        public void SetPlace(MeeterDbContext _context)
        {
            // sets the best place for the meeting
            var locations = _context.Groups.Find(GroupId)
                .Members.Select(member_id => _context.Users.Find(member_id).Location).ToArray();


        }

        public void CalculatePreferences()
        {
            // calculates which preferences are the most important according to UserPreferences
        }

        public float CalculateCrowd(Place place)
        {
            // is the place crowded?
            return 0;
        }
    }
}
