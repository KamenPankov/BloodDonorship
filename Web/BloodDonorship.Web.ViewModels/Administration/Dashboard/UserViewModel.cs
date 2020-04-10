using System;
using System.Collections.Generic;
using BloodDonorship.Data.Models;
using BloodDonorship.Services.Mapping;

namespace BloodDonorship.Web.ViewModels.Administration.Dashboard
{
    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserName { get; set; }

        public string BloodBloodType { get; set; }

        public string BloodRhFactor { get; set; }

        public IEnumerable<RequestViewModel> Requests { get; set; }

        public IEnumerable<DonationViewModel> Donations { get; set; }

        public IEnumerable<NotificationViewModel> Notifications { get; set; }
    }
}
