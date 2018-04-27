using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YosemiteFishingRental.Models;

namespace YosemiteFishingRental.Pages.Files
{
    public class DeleteModel : PageModel
    {
        private readonly YosemiteFishingRental.Data.ApplicationDbContext _context;

        public DeleteModel(YosemiteFishingRental.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public new File File { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            File = await _context.File.SingleOrDefaultAsync(m => m.ID == id);

            if (File == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            File = await _context.File.FindAsync(id);

            if (File != null)
            {
                _context.File.Remove(File);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

    }
}