using System;
namespace Meeter.Models
{
    public class UserPreference
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Preference { get; set; }
    }
}
