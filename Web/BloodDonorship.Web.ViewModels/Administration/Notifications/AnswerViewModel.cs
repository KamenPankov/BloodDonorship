using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BloodDonorship.Web.ViewModels.Administration.Notifications
{
    public class AnswerViewModel
    {
        [Required]
        public string Email { get; set; }

        public string Content { get; set; }
    }
}
