using System;
namespace Meeter.Models
{
    public class User
    {
        public int Id { get; set; }

        public int IdentityUserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public Location Location { get; set; }

        public string Photo { get; set; }
    }
}
