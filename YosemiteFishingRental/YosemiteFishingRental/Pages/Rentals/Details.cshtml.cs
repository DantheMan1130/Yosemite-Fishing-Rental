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
    public class DetailsModel : PageModel
    {
        private readonly YosemiteFishingRental.Data.ApplicationDbContext _context;

        public DetailsModel(YosemiteFishingRental.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Rental Rental { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rental = await _context.Rentals
                .Include(r => r.Product).FirstOrDefaultAsync(m => m.RentalID == id);

            if (Rental == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
