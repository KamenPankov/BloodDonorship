using System;
using System.ComponentModel.DataAnnotations;

using BloodDonorship.Data.Models;
using BloodDonorship.Services.Mapping;

namespace BloodDonorship.Web.ViewModels.Requests
{
    public class RequestPerUserViewModel : IMapFrom<Request>
    {
        public string Id { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Notified People")]
        public int NotifiedUsersCount { get; set; }

        public int DonationsCount { get; set; }
    }
}
