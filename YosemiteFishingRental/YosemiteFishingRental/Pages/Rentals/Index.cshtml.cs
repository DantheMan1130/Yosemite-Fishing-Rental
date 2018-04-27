using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YosemiteFishingRental.Data;
using YosemiteFishingRental.Models;

namespace YosemiteFishingRental.Pages.Rentals
{
    public class IndexModel : PageModel
    {
        private readonly YosemiteFishingRental.Data.ApplicationDbContext _context;

        public IndexModel(YosemiteFishingRental.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        // Added 2 sort filters.
        public string RentalSort { get; set; }
        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Rental> Rental { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            RentalSort = String.IsNullOrEmpty(sortOrder) ? "rental_desc" : "";
            NameSort = sortOrder == "Name" ? "name_desc" : "Name";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Rental> rentalIQ = from r in _context.Rentals.Include(r => r.Product)
                                            select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                rentalIQ = rentalIQ.Where(r => r.CustomerLastName.Contains(searchString)
                               || r.RentalID.ToString() == searchString);
            }

            switch (sortOrder)
            {
                case "rental_desc":
                    rentalIQ = rentalIQ.OrderByDescending(r => r.RentalID);
                    break;
                case "Name":
                    rentalIQ = rentalIQ.OrderBy(r => r.CustomerLastName);
                    break;
                case "name_desc":
                    rentalIQ = rentalIQ.OrderByDescending(r => r.CustomerLastName);
                    break;
                default:
                    rentalIQ = rentalIQ.OrderBy(r => r.RentalID);
                    break;
            }

            int pageSize = 3; // Controls number of records shown on each page.
            Rental = await PaginatedList<Rental>.CreateAsync(
                rentalIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

            //Rental = await rentalIQ.AsNoTracking().ToListAsync(); Taking out with paginated list code.
        }

        /*public async Task OnGetAsync()
        {
            Rental = await _context.Rentals
                .Include(r => r.Product).ToListAsync();
        }*/
    }
}
