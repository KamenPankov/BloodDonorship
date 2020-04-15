using System.Collections.Generic;
using System.Threading.Tasks;

using BloodDonorship.Data.Models;
using BloodDonorship.Data.Models.Enums;
using BloodDonorship.Web.ViewModels.Users;

namespace BloodDonorship.Services.Data.UsersService
{
    public interface IUsersService
    {
        Task<string> AddAnonymousUser(string email);

        IEnumerable<T> GetAllUsers<T>();

        IEnumerable<T> GetAllUsersDeleted<T>();

        string GetUserIdByEmail(string email);

        IEnumerable<EligibleUserViewModel> GetEligibleDonors(ApplicationUser user);

        IEnumerable<(string BloodGroup, string RhFactor)> CompatableBloodTypes(BloodType bloodType, RhFactor rhFactor);

        string MostWantedBloodType();

        string MostDonatedBloodType();

        int AvailableDonors();

        Task DeleteUser(string userId);

        Task UndeleteUser(string userId);
    }
}
