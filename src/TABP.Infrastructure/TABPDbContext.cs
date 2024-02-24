using Microsoft.EntityFrameworkCore;
using TABP.Domain.Entities;
using TABP.Domain.Enums;

namespace TABP.Infrastructure
{
    public class TABPDbContext : DbContext
    {
        public TABPDbContext()
        {

        }
        public TABPDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<HotelType> HotelTypes { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<FeaturedDeal> FeaturedDeals { get; set; }
        public DbSet<HotelImage> HotelImages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
        .HasOne(r => r.Hotel)
        .WithMany(h => h.Rooms)
        .HasForeignKey(r => r.HotelId)
        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Hotel>().HasOne(h => h.HotelType)
                .WithMany(ht => ht.Hotels)
                .HasForeignKey(h => h.HotelTypeId)
                .IsRequired(false);

            modelBuilder.Entity<FeaturedDeal>()
        .HasOne(p => p.Room)
        .WithMany(c => c.FeaturedDeals)
        .HasForeignKey(c => c.RoomId)
        .IsRequired(false);


            SeedingUsers(modelBuilder);
            SeedingHotelType(modelBuilder);
            SeedingRoomType(modelBuilder);
        }


        private void SeedingUsers(ModelBuilder mb)
        {
            mb.Entity<User>().HasData
                (
                new User
                {
                    UserId = Guid.NewGuid(),
                    FirstName = "mohamad",
                    LastName = "moghrabi",
                    Email = "mohamad.moghrabi@gmail.com",
                    Password = "1234",
                    BirthDate = DateTime.Now,
                    UserLevel = UserLevel.Admin,
                }
                );
        }

        private void SeedingHotelType(ModelBuilder mb)
        {
            mb.Entity<HotelType>().HasData
                (
                new HotelType
                {
                    HotelTypeId = Guid.NewGuid(),
                    Type = "perfect"
                }
                );
            mb.Entity<HotelType>().HasData
               (
               new HotelType
               {
                   HotelTypeId = Guid.NewGuid(),
                   Type = "nice"
               }
               );
        }
        private void SeedingRoomType(ModelBuilder mb)
        {
            mb.Entity<RoomType>().HasData
                (
                new RoomType
                {
                    RoomTypeId = Guid.NewGuid(),
                    Type = "perfect"
                }
                );
            mb.Entity<RoomType>().HasData
               (
               new RoomType
               {
                   RoomTypeId = Guid.NewGuid(),
                   Type = "nice"
               }
               );
        }
    }
}
