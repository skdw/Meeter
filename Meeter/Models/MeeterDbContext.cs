using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Meeter.Models
{
    public class MeeterDbContext : DbContext
    {
        public MeeterDbContext(DbContextOptions<MeeterDbContext> options) : base(options) { }

        public DbSet<IdentityUser> IdentityUsers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Place> Places { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<UserPreference> UserPreferences { get; set; }

        public DbSet<Event> Events { get; set; }
    }
}
