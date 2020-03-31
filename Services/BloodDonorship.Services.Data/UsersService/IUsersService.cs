using System.Collections.Generic;

using BloodDonorship.Data.Models;
using BloodDonorship.Data.Models.Enums;
using BloodDonorship.Web.ViewModels.Users;

namespace BloodDonorship.Services.Data.UsersService
{
    public interface IUsersService
    {
        string GetUserIdByEmail(string email);

        IEnumerable<EligibleUserViewModel> GetEligibleDonors(ApplicationUser user);

        IEnumerable<(string BloodGroup, string RhFactor)> CompatableBloodTypes(BloodType bloodType, RhFactor rhFactor);
    }
}
