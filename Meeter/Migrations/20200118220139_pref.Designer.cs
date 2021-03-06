﻿// <auto-generated />
using System;
using Meeter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Meeter.Migrations
{
    [DbContext(typeof(NormalDataContext))]
    [Migration("20200118220139_pref")]
    partial class pref
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Meeter.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("EventName");

                    b.Property<int>("GroupId");

                    b.Property<int>("PlaceId");

                    b.Property<string>("PlaceId1");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("PlaceId1");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Meeter.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Creatorid");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Creatorid");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Meeter.Models.GroupMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupMembers");
                });

            modelBuilder.Entity("Meeter.Models.Location", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<float>("Lat");

                    b.Property<float>("Lng");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Meeter.Models.Place", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Icon");

                    b.Property<string>("LocationId");

                    b.Property<string>("Name");

                    b.Property<bool>("OpenNow");

                    b.Property<string>("PlaceId");

                    b.Property<int>("PriceLevel");

                    b.Property<float>("Rating");

                    b.Property<int>("UserRatingsTotal");

                    b.Property<string>("Vicinity");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Meeter.Models.PlaceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PlaceId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("PlaceTypes");

                    b.HasData(
                        new { Id = 1, Type = "accounting" },
                        new { Id = 2, Type = "airport" },
                        new { Id = 3, Type = "amusement_park" },
                        new { Id = 4, Type = "aquarium" },
                        new { Id = 5, Type = "art_gallery" },
                        new { Id = 6, Type = "atm" },
                        new { Id = 7, Type = "bakery" },
                        new { Id = 8, Type = "bank" },
                        new { Id = 9, Type = "bar" },
                        new { Id = 10, Type = "beauty_salon" },
                        new { Id = 11, Type = "bicycle_store" },
                        new { Id = 12, Type = "book_store" },
                        new { Id = 13, Type = "bowling_alley" },
                        new { Id = 14, Type = "bus_station" },
                        new { Id = 15, Type = "cafe" },
                        new { Id = 16, Type = "campground" },
                        new { Id = 17, Type = "car_dealer" },
                        new { Id = 18, Type = "car_rental" },
                        new { Id = 19, Type = "car_repair" },
                        new { Id = 20, Type = "car_wash" },
                        new { Id = 21, Type = "casino" },
                        new { Id = 22, Type = "cemetery" },
                        new { Id = 23, Type = "church" },
                        new { Id = 24, Type = "city_hall" },
                        new { Id = 25, Type = "clothing_store" },
                        new { Id = 26, Type = "convenience_store" },
                        new { Id = 27, Type = "courthouse" },
                        new { Id = 28, Type = "dentist" },
                        new { Id = 29, Type = "department_store" },
                        new { Id = 30, Type = "doctor" },
                        new { Id = 31, Type = "drugstore" },
                        new { Id = 32, Type = "electrician" },
                        new { Id = 33, Type = "electronics_store" },
                        new { Id = 34, Type = "embassy" },
                        new { Id = 35, Type = "fire_station" },
                        new { Id = 36, Type = "florist" },
                        new { Id = 37, Type = "funeral_home" },
                        new { Id = 38, Type = "furniture_store" },
                        new { Id = 39, Type = "gas_station" },
                        new { Id = 40, Type = "grocery_or_supermarket" },
                        new { Id = 41, Type = "gym" },
                        new { Id = 42, Type = "hair_care" },
                        new { Id = 43, Type = "hardware_store" },
                        new { Id = 44, Type = "hindu_temple" },
                        new { Id = 45, Type = "home_goods_store" },
                        new { Id = 46, Type = "hospital" },
                        new { Id = 47, Type = "insurance_agency" },
                        new { Id = 48, Type = "jewelry_store" },
                        new { Id = 49, Type = "laundry" },
                        new { Id = 50, Type = "lawyer" },
                        new { Id = 51, Type = "library" },
                        new { Id = 52, Type = "light_rail_station" },
                        new { Id = 53, Type = "liquor_store" },
                        new { Id = 54, Type = "local_government_office" },
                        new { Id = 55, Type = "locksmith" },
                        new { Id = 56, Type = "lodging" },
                        new { Id = 57, Type = "meal_delivery" },
                        new { Id = 58, Type = "meal_takeaway" },
                        new { Id = 59, Type = "mosque" },
                        new { Id = 60, Type = "movie_rental" },
                        new { Id = 70, Type = "movie_theater" },
                        new { Id = 71, Type = "moving_company" },
                        new { Id = 72, Type = "museum" },
                        new { Id = 73, Type = "night_club" },
                        new { Id = 74, Type = "painter" },
                        new { Id = 75, Type = "park" },
                        new { Id = 76, Type = "parking" },
                        new { Id = 77, Type = "pet_store" },
                        new { Id = 78, Type = "pharmacy" },
                        new { Id = 79, Type = "physiotherapist" },
                        new { Id = 80, Type = "plumber" },
                        new { Id = 81, Type = "police" },
                        new { Id = 82, Type = "post_office" },
                        new { Id = 83, Type = "primary_school" },
                        new { Id = 84, Type = "real_estate_agency" },
                        new { Id = 85, Type = "restaurant" },
                        new { Id = 86, Type = "roofing_contractor" },
                        new { Id = 87, Type = "rv_park" },
                        new { Id = 88, Type = "school" },
                        new { Id = 89, Type = "secondary_school" },
                        new { Id = 90, Type = "shoe_store" },
                        new { Id = 91, Type = "shopping_mall" },
                        new { Id = 92, Type = "spa" },
                        new { Id = 93, Type = "stadium" },
                        new { Id = 94, Type = "storage" },
                        new { Id = 95, Type = "store" },
                        new { Id = 96, Type = "subway_station" },
                        new { Id = 97, Type = "supermarket" },
                        new { Id = 98, Type = "synagogue" },
                        new { Id = 99, Type = "taxi_stand" },
                        new { Id = 100, Type = "tourist_attraction" },
                        new { Id = 101, Type = "train_station" },
                        new { Id = 102, Type = "transit_station" },
                        new { Id = 103, Type = "travel_agency" },
                        new { Id = 104, Type = "university" },
                        new { Id = 105, Type = "veterinary_care" },
                        new { Id = 106, Type = "zoo" }
                    );
                });

            modelBuilder.Entity("Meeter.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("LocationId");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Photo");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<bool>("isPesudoUser");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Meeter.Models.UserPreference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId");

                    b.Property<int>("PlaceTypeId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("PlaceTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPreferences");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Meeter.Models.Event", b =>
                {
                    b.HasOne("Meeter.Models.Group", "Group")
                        .WithMany("Events")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Meeter.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId1");
                });

            modelBuilder.Entity("Meeter.Models.Group", b =>
                {
                    b.HasOne("Meeter.Models.User", "Creator")
                        .WithMany("CreatedGroups")
                        .HasForeignKey("Creatorid");
                });

            modelBuilder.Entity("Meeter.Models.GroupMember", b =>
                {
                    b.HasOne("Meeter.Models.Group", "Group")
                        .WithMany("Memberships")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Meeter.Models.User", "User")
                        .WithMany("Memberships")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Meeter.Models.Place", b =>
                {
                    b.HasOne("Meeter.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("Meeter.Models.PlaceType", b =>
                {
                    b.HasOne("Meeter.Models.Place")
                        .WithMany("Types")
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("Meeter.Models.User", b =>
                {
                    b.HasOne("Meeter.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("Meeter.Models.UserPreference", b =>
                {
                    b.HasOne("Meeter.Models.Event", "Event")
                        .WithMany("Preferences")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Meeter.Models.PlaceType", "PlaceType")
                        .WithMany()
                        .HasForeignKey("PlaceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Meeter.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Meeter.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Meeter.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Meeter.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Meeter.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
