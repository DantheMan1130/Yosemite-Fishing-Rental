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

        public IList<Rental> Rental { get;set; }

        public async Task OnGetAsync()
        {
            Rental = await _context.Rentals
                .Include(r => r.Product).ToListAsync();
        }
    }
}
