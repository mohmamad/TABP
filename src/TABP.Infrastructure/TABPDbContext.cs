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


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedingUsers(modelBuilder);
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
                    UserLevel = UserLevel.User,
                }
                );
        }

    }
}
