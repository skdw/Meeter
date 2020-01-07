using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Meeter.Models
{
    public class MeeterDbContext : IdentityDbContext
    {
        public MeeterDbContext(DbContextOptions<MeeterDbContext> options) : base(options) { }

       // public DbSet<User> Users { get; set; } // already implemented !!!

       
    }
    public class NormalDataContext:DbContext
    {
        public NormalDataContext(DbContextOptions<NormalDataContext> options) : base(options) { }
        public DbSet<Place> Places { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<GroupMember> GroupMembers { get; set; }

        public DbSet<UserPreference> UserPreferences { get; set; }

        public DbSet<Event> Events { get; set; }
    }
}
