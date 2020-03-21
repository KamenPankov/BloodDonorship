using System.Collections.Generic;

namespace BloodDonorship.Web.ViewModels.Requests
{
    public class DetailsRequestViewModel
    {
        public string Id { get; set; }

        public IEnumerable<DonationInDetailsRequestViewModel> Donations { get; set; }
    }
}
