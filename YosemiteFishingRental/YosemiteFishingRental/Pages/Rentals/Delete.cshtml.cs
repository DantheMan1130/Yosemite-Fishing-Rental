using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YosemiteFishingRental.Data;
using YosemiteFishingRental.Models;

// Not updating with custom delete messages, doesn't seem necessary and already implemented in Products Delete page.
namespace YosemiteFishingRental.Pages.Rentals
{
    public class DeleteModel : PageModel
    {
        private readonly YosemiteFishingRental.Data.ApplicationDbContext _context;

        public DeleteModel(YosemiteFishingRental.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rental Rental { get; set; }
        public string ErrorMessage { get; set; } // Added.

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rental = await _context.Rentals
                .AsNoTracking()
                .Include(r => r.Product)
                .FirstOrDefaultAsync(m => m.RentalID == id);

            if (Rental == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.RentalID == id);

            if (rental == null)
            {
                return NotFound();
            }

            try
            {
                _context.Rentals.Remove(rental);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id = id, saveChangesError = true });
            }

            /* Old, changing to above per tutorial.
            Rental = await _context.Rentals.FindAsync(id);

            if (Rental != null)
            {
                _context.Rentals.Remove(Rental);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");*/
        }
    }
}
