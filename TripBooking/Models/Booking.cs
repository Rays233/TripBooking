﻿namespace TripBooking.Models
{   using System.ComponentModel.DataAnnotations;
    public class Booking
    {
        public int? BookingId { get; set; }
        [Required]
        public int? RoomId { get; set; }

        //public virtual Room Room { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Check-in Date")]
        public DateTime CheckIn { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Check-out Date")]
        [GreaterThan("CheckIn", ErrorMessage = "Check-out date must be after check-in date.")]
        public DateTime CheckOut { get; set; }
        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; }
    }
}
