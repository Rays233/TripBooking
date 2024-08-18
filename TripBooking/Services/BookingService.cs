﻿using Microsoft.EntityFrameworkCore;
using TripBooking.DAL;
using TripBooking.Models;
namespace TripBooking.Services
{
    public interface IBookingService
    {
        Booking CreateBooking(Booking booking);
        Booking GetBookingById(int id);
        List<Booking> GetAllBookings(); 
    }
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _context;

        public BookingService(AppDbContext context)
        {
            _context = context;
        }

        public Booking CreateBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return(booking);
        }

        public Booking GetBookingById(int id)
        {
            return _context.Bookings
                           .Include(b => b.Room)
                           .Include(b=>b.Customer)
                           .FirstOrDefault(b => b.BookingId == id);
        }

        public List<Booking> GetAllBookings()
        {
            return _context.Bookings
                           .Include(b => b.Room)
                           .Include(b=>b.Customer)
                           .ToList();
        }
    }

}
