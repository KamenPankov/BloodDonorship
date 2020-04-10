using System.Collections.Generic;
using System.Linq;

namespace BloodDonorship.Web.ViewModels.Administration.Dashboard
{
    public class IndexViewModel
    {
        public int SettingsCount { get; set; }

        public string MostWantedBloodType { get; set; }

        public string MostDonatedBloodType { get; set; }

        public int AvailableDonors { get; set; }

        public int UsersCount => this.Users.Count();

        public int RequestsCount => this.Users.SelectMany(x => x.Requests).Count();

        public int DonationsCount => this.Users.SelectMany(x => x.Donations).Count();

        public IEnumerable<UserViewModel> Users { get; set; }
    }
}
