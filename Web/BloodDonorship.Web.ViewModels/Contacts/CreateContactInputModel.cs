﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BloodDonorship.Web.ViewModels.Contacts
{
    public class CreateContactInputModel
    {
        [Display(Name = "From:")]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string UserEmail { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Message must contains at least 10 characters.")]
        [MaxLength(1000, ErrorMessage = "Message must contains less than 1000 characters.")]
        public string Content { get; set; }
    }
}
