using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using BloodDonorship.Data;
using BloodDonorship.Web.ViewModels.Donations;

namespace BloodDonorship.Services.Data.DonationsService
{
    public interface IDonationsService
    {
        Task AddAsync(CreateDonationViewModel viewModel);

        DateTime LastDonationDate(string userId); // donor
    }
}
