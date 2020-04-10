using System;
using BloodDonorship.Data.Models;
using BloodDonorship.Services.Mapping;

namespace BloodDonorship.Web.ViewModels.Administration.Dashboard
{
    public class DonationViewModel : IMapFrom<Donation>
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; } // sender

        public string RequestId { get; set; }
    }
}
