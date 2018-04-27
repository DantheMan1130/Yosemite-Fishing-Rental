using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YosemiteFishingRental.Models
{
    public class File
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string PublicFile { get; set; }

        [Display(Name = "Public File Size (bytes)")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public long PublicFileSize { get; set; }

        public string PrivateFile { get; set; }

        [Display(Name = "Private File Size (bytes)")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public long PrivateFileSize { get; set; }

        [Display(Name = "Uploaded")]
        [DisplayFormat(DataFormatString = "{0:F}")]
        public DateTime UploadDT { get; set; }
    }
}
