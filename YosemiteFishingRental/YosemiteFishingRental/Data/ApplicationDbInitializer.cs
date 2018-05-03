using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YosemiteFishingRental.Models;

namespace YosemiteFishingRental.Data
{
    public class ApplicationDbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // context.Database.EnsureCreated(); // Tutorial said to comment out.

            // Look for any products.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var products = new Product[]
            {
                new Product{ProductID=1234, ProductName="Fishing Rod - Adult", ProductDescription="A basic fishing rod suitable for a beginner.", RentorPurchase=RentorPurchase.Rent,  Price=25,  RentalPeriod=24, Quantity=50},
                new Product{ProductID=4321, ProductName="Fishing Rod - Child", ProductDescription="A basic fishing rod suitable for children under 12 years old.", RentorPurchase=RentorPurchase.Rent,  Price=15,  RentalPeriod=24, Quantity=50},
                new Product{ProductID=6789, ProductName="Bait", ProductDescription="Worms that can be used as bait.", RentorPurchase=RentorPurchase.Purchase,  Price=5,  RentalPeriod=null, Quantity=100},
                new Product{ProductID=9876, ProductName="Small Tackle Box (lures included)", ProductDescription="Tackle box including 25+ assorted lures.", RentorPurchase=RentorPurchase.Rent,  Price=10,  RentalPeriod=24, Quantity=10},
                new Product{ProductID=5500, ProductName="Raft (2-person)", ProductDescription="An inflatable 2-person raft with oars.", RentorPurchase=RentorPurchase.Rent,  Price=50,  RentalPeriod=5, Quantity=5}
            };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

            // Seed test rentals, based off of product information.
            var rentals = new Rental[]
            {
                new Rental{RentalID=123456, ProductID=1234, CustomerFirstName="Dan", CustomerLastName="Foster", CustomerEmail="dfoster1130@gmail.com", CustomerPhone="6195654555", RentalDate=DateTime.Parse("2018-12-01"), RentalPaid=RentalPaid.No},
                new Rental{RentalID=654321, ProductID=4321, CustomerFirstName="Vahe", CustomerLastName="Ohanian", CustomerEmail="vohanian@gmail.com", CustomerPhone="6195989661", RentalDate=DateTime.Parse("2017-11-15"), RentalPaid=RentalPaid.Yes},
                new Rental{RentalID=567890, ProductID=9876, CustomerFirstName="Billy", CustomerLastName="Bob", CustomerEmail="billybob123@gmail.com", CustomerPhone=null, RentalDate=DateTime.Parse("2017-06-10"), RentalPaid=RentalPaid.No},
                new Rental{RentalID=198765, ProductID=6789, CustomerFirstName="LeBron", CustomerLastName="James", CustomerEmail="kingjames@yahoo.com", CustomerPhone="6192528509", RentalDate=DateTime.Parse("2018-01-26"), RentalPaid=RentalPaid.No},
                new Rental{RentalID=112233, ProductID=5500, CustomerFirstName="John", CustomerLastName="Muir", CustomerEmail="jmconservancy@hotmail.com", CustomerPhone="6192547897", RentalDate=DateTime.Parse("2018-05-04"), RentalPaid=RentalPaid.Yes}
            };
            foreach (Rental r in rentals)
            {
                context.Rentals.Add(r);
            }
            context.SaveChanges();
        }
    }
}
