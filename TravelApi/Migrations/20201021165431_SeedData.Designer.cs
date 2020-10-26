﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelApi.Models;

namespace TravelApi.Migrations
{
    [DbContext(typeof(TravelApiContext))]
    [Migration("20201021165431_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TravelApi.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("ReviewCount");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            CountryId = 1,
                            Name = "Vancouver",
                            ReviewCount = 0
                        },
                        new
                        {
                            CityId = 2,
                            CountryId = 5,
                            Name = "London",
                            ReviewCount = 0
                        },
                        new
                        {
                            CityId = 3,
                            CountryId = 2,
                            Name = "Tokyo",
                            ReviewCount = 0
                        },
                        new
                        {
                            CityId = 4,
                            CountryId = 4,
                            Name = "Sydney",
                            ReviewCount = 0
                        },
                        new
                        {
                            CityId = 5,
                            CountryId = 3,
                            Name = "Paris",
                            ReviewCount = 0
                        },
                        new
                        {
                            CityId = 6,
                            CountryId = 1,
                            Name = "Montreal",
                            ReviewCount = 0
                        });
                });

            modelBuilder.Entity("TravelApi.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            Name = "Canada"
                        },
                        new
                        {
                            CountryId = 2,
                            Name = "Japan"
                        },
                        new
                        {
                            CountryId = 3,
                            Name = "France"
                        },
                        new
                        {
                            CountryId = 4,
                            Name = "Australia"
                        },
                        new
                        {
                            CountryId = 5,
                            Name = "UK"
                        });
                });

            modelBuilder.Entity("TravelApi.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CityId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("ReviewScore");

                    b.Property<string>("ReviewText");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ReviewId");

                    b.HasIndex("CityId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            ReviewId = 1,
                            CityId = 3,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReviewScore = 10,
                            ReviewText = "Wonderful city, a lot to do and see!",
                            UserName = "Kurokeh"
                        },
                        new
                        {
                            ReviewId = 2,
                            CityId = 1,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReviewScore = 5,
                            ReviewText = "Okay but it smelled like weed everywhere",
                            UserName = "Bmead"
                        },
                        new
                        {
                            ReviewId = 3,
                            CityId = 5,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReviewScore = 7,
                            ReviewText = "Lovely city, some of the people weren't nice though",
                            UserName = "Bmead"
                        });
                });

            modelBuilder.Entity("TravelApi.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TravelApi.Models.City", b =>
                {
                    b.HasOne("TravelApi.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelApi.Models.Review", b =>
                {
                    b.HasOne("TravelApi.Models.City", "City")
                        .WithMany("Reviews")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
