using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace YosemiteFishingRental.Models
{
    public class FileUpload
    {
        [Required]
        [Display(Name = "Upload Title")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Upload title must be between 3 and 50 characters.")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Public File")]
        public IFormFile UploadPublicFile { get; set; }

        [Required]
        [Display(Name = "Private File")]
        public IFormFile UploadPrivateFile { get; set; }
    }
}
