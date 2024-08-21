using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TripBooking.Models;
namespace TripBooking.DAL;


public class AppDbContext : IdentityDbContext<ApplicationUser>
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

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelId);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);

            //Seeding data for hotels
            entity.HasData(
                   new Hotel { HotelId = 1, Name = "Hotel One", Description = "Description for Hotel One", City="Alicante", Country="Spain" },
                   new Hotel { HotelId = 2, Name = "Hotel Two", Description = "Description for Hotel Two",City="Malaga",Country="Spain" }
            );
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Price).IsRequired();

            entity.HasOne<Hotel>()
                    .WithMany(h => h.Rooms)
                    .HasForeignKey(e => e.HotelId)
                    .OnDelete(DeleteBehavior.Cascade);

            entity.HasData(
                       new Room { RoomId = 1, Name = "Standard Room", Description = "Description for Standard Room", Price = 100, HotelId = 1 },
                       new Room { RoomId = 2, Name = "Deluxe Room", Description = "Description for Deluxe Room", Price = 150, HotelId = 2 },
                       new Room { RoomId = 3, Name = "Suite", Description = "Description for Suite", Price = 200, HotelId = 2 },
                       new Room { RoomId = 4, Name = "Presidential Suite", Description = "Description for Presidential Suite", Price = 300, HotelId = 2 }
               );
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId);
            entity.Property(e => e.CheckIn).IsRequired();
            entity.Property(e => e.CheckOut).IsRequired();
            entity.Property(e => e.CustomerEmail).IsRequired().HasMaxLength(100);


            entity.HasOne<Room>()
                  .WithMany()
                  .HasForeignKey(e => e.RoomId)
                  .OnDelete(DeleteBehavior.Restrict);

        });
         modelBuilder.Entity<Customer>(entity =>
         {
             entity.HasKey(e => e.CustomerId);
             entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
             entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
         });
    }
}
