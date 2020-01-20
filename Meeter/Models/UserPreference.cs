using System;
namespace Meeter.Models
{
    public class UserPreference
    {
        public int Id { get; set; }

        //public int UserId { get; set; }

        //public int EventId { get; set; }

        public int TypeId { get; set; }
        public virtual Type Type { get; set; }

        public virtual User User { get; set; }
        public string UserId { get; set; }

        public virtual Event Event { get; set; }
        public int EventId { get; set; }
    }
}
