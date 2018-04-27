using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YosemiteFishingRental.Models;
using YosemiteFishingRental.Utilities;
using YosemiteFishingRental.Data;

namespace YosemiteFishingRental.Pages.Files
{
    public class IndexModel : PageModel
    {
        private readonly YosemiteFishingRental.Data.ApplicationDbContext _context;

        public IndexModel(YosemiteFishingRental.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FileUpload FileUpload { get; set; }

        public new IList<File> File { get; private set; }

        public async Task OnGetAsync()
        {
            File = await _context.File.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Perform an initial check to catch FileUpload class
            // attribute violations.
            if (!ModelState.IsValid)
            {
                File = await _context.File.AsNoTracking().ToListAsync();
                return Page();
            }

            var publicFileData =
                await FileHelpers.ProcessFormFile(FileUpload.UploadPublicFile, ModelState);

            var privateFileData =
                await FileHelpers.ProcessFormFile(FileUpload.UploadPrivateFile, ModelState);

            // Perform a second check to catch ProcessFormFile method
            // violations.
            if (!ModelState.IsValid)
            {
                File = await _context.File.AsNoTracking().ToListAsync();
                return Page();
            }

            var file = new File()
            {
                PublicFile = publicFileData,
                PublicFileSize = FileUpload.UploadPublicFile.Length,
                PrivateFile = privateFileData,
                PrivateFileSize = FileUpload.UploadPrivateFile.Length,
                Title = FileUpload.Title,
                UploadDT = DateTime.Now
            };

            _context.File.Add(file);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}