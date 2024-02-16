﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TABP.Infrastructure;

#nullable disable

namespace TABP.Infrastructure.Migrations
{
    [DbContext(typeof(TABPDbContext))]
    partial class TABPDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TABP.Domain.Entities.Booking", b =>
                {
                    b.Property<Guid>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookingId");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("TABP.Domain.Entities.City", b =>
                {
                    b.Property<Guid>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CityDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("TABP.Domain.Entities.FeaturedDeal", b =>
                {
                    b.Property<Guid>("FeaturedDealId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("FeaturedDealId");

                    b.HasIndex("RoomId");

                    b.ToTable("FeaturedDeals");
                });

            modelBuilder.Entity("TABP.Domain.Entities.Hotel", b =>
                {
                    b.Property<Guid>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Amenities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("HotelTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("HotelId");

                    b.HasIndex("HotelTypeId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("TABP.Domain.Entities.HotelImage", b =>
                {
                    b.Property<Guid>("HotelImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HotelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HotelImageId");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelImages");
                });

            modelBuilder.Entity("TABP.Domain.Entities.HotelType", b =>
                {
                    b.Property<Guid>("HotelTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HotelTypeId");

                    b.ToTable("HotelTypes");

                    b.HasData(
                        new
                        {
                            HotelTypeId = new Guid("17dec853-2fd8-4b7b-a41e-67d250dd313c"),
                            Type = "perfect"
                        },
                        new
                        {
                            HotelTypeId = new Guid("0c1318a9-804c-4ccd-a894-cfd2b255ae34"),
                            Type = "nice"
                        });
                });

            modelBuilder.Entity("TABP.Domain.Entities.Location", b =>
                {
                    b.Property<Guid>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HotelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.HasIndex("CityId");

                    b.HasIndex("HotelId")
                        .IsUnique();

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("TABP.Domain.Entities.Review", b =>
                {
                    b.Property<Guid>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("HotelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReviewId");

                    b.HasIndex("HotelId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("TABP.Domain.Entities.Room", b =>
                {
                    b.Property<Guid>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<Guid>("HotelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAvaiable")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<Guid>("RoomTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoomId");

                    b.HasIndex("HotelId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("TABP.Domain.Entities.RoomType", b =>
                {
                    b.Property<Guid>("RoomTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomTypeId");

                    b.ToTable("RoomTypes");

                    b.HasData(
                        new
                        {
                            RoomTypeId = new Guid("7828f8e5-28b4-4a5f-b06a-cdcf687e9e2a"),
                            Type = "perfect"
                        },
                        new
                        {
                            RoomTypeId = new Guid("f90796ee-836b-4515-8093-e8aa6cd3019d"),
                            Type = "nice"
                        });
                });

            modelBuilder.Entity("TABP.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserLevel")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("a24bda68-3b47-4bef-9cc1-be3475def205"),
                            BirthDate = new DateTime(2024, 2, 16, 23, 44, 47, 727, DateTimeKind.Local).AddTicks(8329),
                            Email = "mohamad.moghrabi@gmail.com",
                            FirstName = "mohamad",
                            LastName = "moghrabi",
                            Password = "1234",
                            UserLevel = 2
                        });
                });

            modelBuilder.Entity("TABP.Domain.Entities.Booking", b =>
                {
                    b.HasOne("TABP.Domain.Entities.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TABP.Domain.Entities.User", "User")
                        .WithMany("bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TABP.Domain.Entities.FeaturedDeal", b =>
                {
                    b.HasOne("TABP.Domain.Entities.Room", "Room")
                        .WithMany("FeaturedDeals")
                        .HasForeignKey("RoomId");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("TABP.Domain.Entities.Hotel", b =>
                {
                    b.HasOne("TABP.Domain.Entities.HotelType", "HotelType")
                        .WithMany("Hotels")
                        .HasForeignKey("HotelTypeId");

                    b.Navigation("HotelType");
                });

            modelBuilder.Entity("TABP.Domain.Entities.HotelImage", b =>
                {
                    b.HasOne("TABP.Domain.Entities.Hotel", "Hotel")
                        .WithMany("Images")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("TABP.Domain.Entities.Location", b =>
                {
                    b.HasOne("TABP.Domain.Entities.City", "City")
                        .WithMany("locations")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TABP.Domain.Entities.Hotel", "Hotel")
                        .WithOne("Location")
                        .HasForeignKey("TABP.Domain.Entities.Location", "HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("TABP.Domain.Entities.Review", b =>
                {
                    b.HasOne("TABP.Domain.Entities.Hotel", "Hotel")
                        .WithMany("Reviews")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TABP.Domain.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TABP.Domain.Entities.Room", b =>
                {
                    b.HasOne("TABP.Domain.Entities.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TABP.Domain.Entities.RoomType", "RoomType")
                        .WithMany("rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("TABP.Domain.Entities.City", b =>
                {
                    b.Navigation("locations");
                });

            modelBuilder.Entity("TABP.Domain.Entities.Hotel", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Location")
                        .IsRequired();

                    b.Navigation("Reviews");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("TABP.Domain.Entities.HotelType", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("TABP.Domain.Entities.Room", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("FeaturedDeals");
                });

            modelBuilder.Entity("TABP.Domain.Entities.RoomType", b =>
                {
                    b.Navigation("rooms");
                });

            modelBuilder.Entity("TABP.Domain.Entities.User", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
