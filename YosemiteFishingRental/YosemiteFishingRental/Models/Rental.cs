using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YosemiteFishingRental.Models
{
    public enum RentalPaid
    {
        Yes, No
    }

    public class Rental
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Rental ID (includes purchases)")]
        [Range(0, 999999)]
        public int RentalID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Product")]
        [Range(0, 9999)]
        public int ProductID { get; set; }

        [Required]
        [Display(Name = "Customer First Name")]
        [StringLength(25, ErrorMessage = "Customer first name cannot be longer than 25 characters.")]
        public string CustomerFirstName { get; set; }

        [Required]
        [Display(Name = "Customer Last Name")]
        [StringLength(25, ErrorMessage = "Customer last name cannot be longer than 25 characters.")]
        public string CustomerLastName { get; set; }

        [StringLength(50, ErrorMessage = "Customer email cannot be longer than 50 characters.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Customer Email")]
        [DisplayFormat(NullDisplayText = "No email specified.")]
        public string CustomerEmail { get; set; }

        [StringLength(20, ErrorMessage = "Customer phone number cannot be longer than 20 characters.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Customer Phone")]
        [DisplayFormat(NullDisplayText = "No phone number specified.")]
        public string CustomerPhone { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime RentalDate { get; set; }

        [Required]
        [Display(Name = "Paid?")]
        public RentalPaid RentalPaid { get; set; }

        public Product Product { get; set; }
    }
}
