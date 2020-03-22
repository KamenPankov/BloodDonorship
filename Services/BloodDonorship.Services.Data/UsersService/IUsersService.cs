using System.Collections.Generic;

using BloodDonorship.Data.Models;
using BloodDonorship.Web.ViewModels.Users;

namespace BloodDonorship.Services.Data.UsersService
{
    public interface IUsersService
    {
        IEnumerable<EligibleUserViewModel> GetEligibleDonors(ApplicationUser user);
    }
}
