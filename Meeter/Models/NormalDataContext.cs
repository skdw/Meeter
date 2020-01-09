using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Meeter.Models
{
    //public class MeeterDbContext : IdentityDbContext<User, Role, string>
    //{
    //    public MeeterDbContext(DbContextOptions<MeeterDbContext> options) : base(options) { }


    //    public DbSet<Group> Groups { get; set; }
    //}
    public class NormalDataContext : IdentityDbContext<User, Role, string>
    {
        public NormalDataContext(DbContextOptions<NormalDataContext> options) : base(options) { }
        public DbSet<Place> Places { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<GroupMember> GroupMembers { get; set; }

        public DbSet<UserPreference> UserPreferences { get; set; }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Core Identity model and override the defaults if needed. 

            //builder.Entity<IdentityUserRole<Guid>>().HasKey(p => new { p.UserId, p.RoleId });
        }
    }
}
