using System;
namespace Meeter.Models
{
    public class UserPreference
    {
        public int Id { get; set; }

        //public int UserId { get; set; }

        //public int EventId { get; set; }

        public string Preference { get; set; }

        public virtual User User { get; set; }

        public virtual Event Event { get; set; }
    }
}
