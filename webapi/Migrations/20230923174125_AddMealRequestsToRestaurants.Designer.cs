﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapi.Data;

#nullable disable

namespace webapi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230923174125_AddMealRequestsToRestaurants")]
    partial class AddMealRequestsToRestaurants
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MealRequestsCompanions", b =>
                {
                    b.Property<string>("CompanionsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MealRequestModelId")
                        .HasColumnType("int");

                    b.HasKey("CompanionsId", "MealRequestModelId");

                    b.HasIndex("MealRequestModelId");

                    b.ToTable("MealRequestsCompanions");
                });

            modelBuilder.Entity("webapi.Models.MealRequestModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("MealRequests");
                });

            modelBuilder.Entity("webapi.Models.RestaurantModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Budget")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Style")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main Street",
                            Budget = "$$$",
                            CreatorId = "1",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A cozy place with delicious food.",
                            Name = "Restaurant 1",
                            Style = "Italian"
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Elm Avenue",
                            Budget = "$$",
                            CreatorId = "2",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Authentic flavors from around the world.",
                            Name = "Restaurant 2",
                            Style = "Asian Fusion"
                        },
                        new
                        {
                            Id = 3,
                            Address = "789 Oak Street",
                            Budget = "$$$",
                            CreatorId = "3",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A modern atmosphere with a diverse menu.",
                            Name = "Restaurant 3",
                            Style = "American"
                        },
                        new
                        {
                            Id = 4,
                            Address = "101 Maple Road",
                            Budget = "$$$$",
                            CreatorId = "4",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Experience fine dining at its best.",
                            Name = "Restaurant 4",
                            Style = "French"
                        },
                        new
                        {
                            Id = 5,
                            Address = "222 Pine Lane",
                            Budget = "$$",
                            CreatorId = "5",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Savor the taste of authentic sushi.",
                            Name = "Restaurant 5",
                            Style = "Japanese"
                        });
                });

            modelBuilder.Entity("webapi.Models.UserModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int?>("BudgetMax")
                        .HasColumnType("int");

                    b.Property<int?>("BudgetMin")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateJoined")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "97ef8d94-32e2-4cae-87e8-828a2072d9f2",
                            DateJoined = new DateTime(2023, 9, 23, 17, 41, 24, 348, DateTimeKind.Utc).AddTicks(6515),
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user1@test.ca",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER1@TEST.CA",
                            NormalizedUserName = "USER1",
                            PasswordHash = "AQAAAAIAAYagAAAAEP3LWqDt0aU6ybSun9xV0I5NHyTdVGwGS0FwVSPKc5FEpYOIdQEC5H/s80gBvCmXyQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9f26d89a-006f-459b-a655-7f8dd3892431",
                            TwoFactorEnabled = false,
                            UserName = "user1"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "dba33f1c-d4e4-4662-8467-a952e5b8b203",
                            DateJoined = new DateTime(2023, 9, 23, 17, 41, 24, 489, DateTimeKind.Utc).AddTicks(2371),
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user2@test.ca",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER2@TEST.CA",
                            NormalizedUserName = "USER2",
                            PasswordHash = "AQAAAAIAAYagAAAAEApGlNFuCgvWtUKaCMX9vBQSIVVJDV+fuEcxfAcqbqprbRSqnmPQ8PQQLv5WtpTd/A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "eddfa61c-0315-47df-b9bb-4bdb182d4425",
                            TwoFactorEnabled = false,
                            UserName = "user2"
                        },
                        new
                        {
                            Id = "3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6be36fe6-3c88-4d26-b3d4-34c85fddacb6",
                            DateJoined = new DateTime(2023, 9, 23, 17, 41, 24, 639, DateTimeKind.Utc).AddTicks(2679),
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user3@test.ca",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER3@TEST.CA",
                            NormalizedUserName = "USER3",
                            PasswordHash = "AQAAAAIAAYagAAAAEES55F1MxlIbJBwGGm3bi5FmMtL5wRXa95G2A45UepKOfEUbQclXGB+5kvWqupKmRw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3833b5df-ac0a-493d-937d-441823887572",
                            TwoFactorEnabled = false,
                            UserName = "user3"
                        },
                        new
                        {
                            Id = "4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e4a695f4-347e-4cb4-8481-757b529ae2bf",
                            DateJoined = new DateTime(2023, 9, 23, 17, 41, 24, 784, DateTimeKind.Utc).AddTicks(2213),
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user4@test.ca",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER4@TEST.CA",
                            NormalizedUserName = "USER4",
                            PasswordHash = "AQAAAAIAAYagAAAAEAl8YKRmXCEInqhiDgTjHm9HvOIsCCRccj5y6feKPXID63TXBBrGFd1EV7RINtmwcg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e090f09b-0b9c-4cf1-a159-db9edfa43510",
                            TwoFactorEnabled = false,
                            UserName = "user4"
                        },
                        new
                        {
                            Id = "5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1729cbb0-96a8-4423-a5c1-e12a119749f4",
                            DateJoined = new DateTime(2023, 9, 23, 17, 41, 24, 921, DateTimeKind.Utc).AddTicks(1675),
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user5@test.ca",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER5@TEST.CA",
                            NormalizedUserName = "USER5",
                            PasswordHash = "AQAAAAIAAYagAAAAEA1e9xcR12zUPVwo2ss0WK8QBwZ2mbFTSNd4c+/uTYYqWYy/YXNcvc3WC+hMe6qCyA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9a3b6187-48bc-484a-a49f-d911f2f9ee63",
                            TwoFactorEnabled = false,
                            UserName = "user5"
                        });
                });

            modelBuilder.Entity("MealRequestsCompanions", b =>
                {
                    b.HasOne("webapi.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("CompanionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Models.MealRequestModel", null)
                        .WithMany()
                        .HasForeignKey("MealRequestModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("webapi.Models.MealRequestModel", b =>
                {
                    b.HasOne("webapi.Models.UserModel", "Creator")
                        .WithMany("CreatedMealRequests")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Models.RestaurantModel", "Restaurant")
                        .WithMany("MealRequests")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("webapi.Models.RestaurantModel", b =>
                {
                    b.HasOne("webapi.Models.UserModel", "Creator")
                        .WithMany("CreatedRestaurants")
                        .HasForeignKey("CreatorId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("webapi.Models.RestaurantModel", b =>
                {
                    b.Navigation("MealRequests");
                });

            modelBuilder.Entity("webapi.Models.UserModel", b =>
                {
                    b.Navigation("CreatedMealRequests");

                    b.Navigation("CreatedRestaurants");
                });
#pragma warning restore 612, 618
        }
    }
}
