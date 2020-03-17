using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Microsoft.AspNetCore.Http;

namespace BloodDonorship.Web.ViewModels.Donations
{
    public class CreateDonationViewModel
    {
        [Required]
        public string RequestId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required(ErrorMessage = "No file is chosen. Please choose a file!")]
        [Display(Name = "Verification Document")]
        public IFormFile FormFile { get; set; }
    }
}
