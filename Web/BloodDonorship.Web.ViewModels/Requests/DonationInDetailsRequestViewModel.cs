using BloodDonorship.Data.Models;
using BloodDonorship.Services.Mapping;

namespace BloodDonorship.Web.ViewModels.Requests
{

    public class DonationInDetailsRequestViewModel : IMapFrom<Donation>
    {
        public string Id { get; set; }

        public string ImageTitle { get; set; }

        public byte[] ImageData { get; set; }
    }
}
