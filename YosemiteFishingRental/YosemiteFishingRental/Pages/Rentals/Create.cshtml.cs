using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using YosemiteFishingRental.Data;
using YosemiteFishingRental.Models;

namespace YosemiteFishingRental.Pages.Rentals
{
    public class CreateModel : PageModel
    {
        private readonly YosemiteFishingRental.Data.ApplicationDbContext _context;

        public CreateModel(YosemiteFishingRental.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductName");
            return Page();
        }

        [BindProperty]
        public Rental Rental { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rentals.Add(Rental);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}