using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YosemiteFishingRental.Data;
using YosemiteFishingRental.Models;

// Edited to comply with tutorial.
namespace YosemiteFishingRental.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly YosemiteFishingRental.Data.ApplicationDbContext _context;

        public DeleteModel(YosemiteFishingRental.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }
        public string ErrorMessage { get; set; } // Added.

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false) // Was public async Task<IActionResult> OnGetAsync(int? id).
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products
                .AsNoTracking() // Added.
                .FirstOrDefaultAsync(m => m.ProductID == id);

            if (Product == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault()) // Added.
            {
                ErrorMessage = "Delete failed. Try again.";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products
                .AsNoTracking() // Added.
                .FirstOrDefaultAsync(m => m.ProductID == id); // Changed, was .FindAsync(id);.

            if (Product == null)
            {
                return NotFound();
            }

            try
            {
                _context.Products.Remove(Product);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id = id, saveChangesError = true });
            }

            /*if (Product != null) Tutorial said to take out.
            {
                _context.Products.Remove(Product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");*/
        }
    }
}
