using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YosemiteFishingRental.Models
{
    // No longer using enum, just using string for RentorPurchase. Was using <select> tag in Create and Edit HTML pages with enum.
    public enum RentorPurchase
    {
        Rent, Purchase
    }

    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Product ID")]
        [Range(0, 9999)]
        public int ProductID { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        [StringLength(50, ErrorMessage = "Product name cannot be longer than 50 characters.")]
        public string ProductName { get; set; }

        [Display(Name = "Product Description")]
        [DataType(DataType.MultilineText)]
        [StringLength(100, ErrorMessage = "Product description cannot be longer than 100 characters.")]
        [DisplayFormat(NullDisplayText = "No description.")]
        public string ProductDescription { get; set; }

        [Display(Name = "Rent/Purchase")]
        //[StringLength(10, ErrorMessage = "Rent or purchase only.")]
        [DisplayFormat(NullDisplayText = "Not for rent or purchase.")]
        public RentorPurchase? RentorPurchase { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Range(0, 100000, ErrorMessage = "Price must be between $0 and $100,000.")]
        public decimal Price { get; set; }

        [Display(Name = "Rental Period (hours)")]
        [DisplayFormat(NullDisplayText = "Not rentable.")]
        [Range(0, 9999, ErrorMessage = "Rental period must be between 0 and 9,999 hours.")]
        public int? RentalPeriod { get; set; }

        [Display(Name = "Quantity Available")]
        [DisplayFormat(NullDisplayText = "No quantity specified.")]
        [Range(0, 9999, ErrorMessage = "Quantity must be between 0 and 9,999 units.")]
        public int? Quantity { get; set; }

        public ICollection<Rental> Rentals { get; set; }
    }
}
