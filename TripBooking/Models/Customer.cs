using System.ComponentModel.DataAnnotations;

namespace TripBooking.Models
{
    public class Customer
    {
        public int CustomerId { get; set; } //primary key so no data validation needed

        [Required(ErrorMessage = "Full name is required.")]
        [Display(Name = "Full Name")]
        [StringLength(50, ErrorMessage = "Full name must not exceed 100 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(50, ErrorMessage = "Email must not exceed 100 characters.")]
        public string Email { get; set; }
    }
}
