using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Newtonsoft.Json;
using Meeter;
using System.IO;

namespace Meeter.Models
{
    //public class MeeterDbContext : IdentityDbContext<User, Role, string>
    //{
    //    public MeeterDbContext(DbContextOptions<MeeterDbContext> options) : base(options) { }


    //    public DbSet<Group> Groups { get; set; }
    //}
    public class NormalDataContext : IdentityDbContext<User, IdentityRole, string>
    {
        public NormalDataContext(DbContextOptions<NormalDataContext> options) : base(options) { }

        public DbSet<Type> Types { get; set; }

        public DbSet<Place> Places { get; set; }

        public DbSet<PlaceType> PlaceTypes { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<GroupMember> GroupMembers { get; set; }

        public DbSet<UserPreference> UserPreferences { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var myJsonString = File.ReadAllText("preferences.json");
            List<Type> ptypes = JsonConvert.DeserializeObject<List<Type>>(myJsonString);
            builder.Entity<Type>().HasData(ptypes.ToArray());
            // Customize the ASP.NET Core Identity model and override the defaults if needed. 

            //builder.Entity<IdentityUserRole<Guid>>().HasKey(p => new { p.UserId, p.RoleId });
        }
    }
}
