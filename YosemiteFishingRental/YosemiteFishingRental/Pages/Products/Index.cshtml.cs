using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YosemiteFishingRental.Data;
using YosemiteFishingRental.Models;

namespace YosemiteFishingRental.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly YosemiteFishingRental.Data.ApplicationDbContext _context;

        public IndexModel(YosemiteFishingRental.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        // Added 2 sort filters.
        public string ProductSort { get; set; }
        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Product> Product { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            ProductSort = String.IsNullOrEmpty(sortOrder) ? "product_desc" : "";
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

            IQueryable<Product> productIQ = from p in _context.Products
                                            select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                productIQ = productIQ.Where(p => p.ProductName.Contains(searchString)
                               || p.ProductID.ToString() == searchString);
            }

            switch (sortOrder)
            {
                case "product_desc":
                    productIQ = productIQ.OrderByDescending(p => p.ProductID);
                    break;
                case "Name":
                    productIQ = productIQ.OrderBy(p => p.ProductName);
                    break;
                case "name_desc":
                    productIQ = productIQ.OrderByDescending(p => p.ProductName);
                    break;
                default:
                    productIQ = productIQ.OrderBy(p => p.ProductID);
                    break;
            }

            int pageSize = 3; // Controls number of records shown on each page.
            Product = await PaginatedList<Product>.CreateAsync(
                productIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

            // Product = await productIQ.AsNoTracking().ToListAsync(); Taking out with paginated list code.
        }

        /*public async Task OnGetAsync() // Updated to include sorting.
        {
            Product = await _context.Products.ToListAsync();
        }*/
    }
}
