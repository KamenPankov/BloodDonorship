using BloodDonorship.Web.ViewModels.Users;
using System.Collections.Generic;

namespace BloodDonorship.Services.Data.UsersService
{
    public interface IUsersService
    {
        IEnumerable<EligibleUserViewModel> GetEligibleDonors(string userId);
    }
}
