namespace TripBooking.DAL
{
    using Microsoft.EntityFrameworkCore;
    using TripBooking.Models;
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seeding mockup Hotels
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { HotelId = 1, Name = "Seaside Resort", City = "Malaga", Country = "Spain" },
                new Hotel { HotelId = 2, Name = "Mountain Lodge", City = "Chamonix", Country = "France" },
                new Hotel { HotelId = 3, Name = "City Center Hotel", City = "Berlin", Country = "Germany" }
            );

            // Seeding mockup rooms
            modelBuilder.Entity<Room>().HasData(
                new Room { RoomId = 1, HotelId = 1, Type = "Standard" },
                new Room { RoomId = 2, HotelId = 1, Type = "Deluxe" },
                new Room { RoomId = 3, HotelId = 2, Type = "Suite" },
                new Room { RoomId = 4, HotelId = 3, Type = "Standard" }
            );
        }
    }
}
