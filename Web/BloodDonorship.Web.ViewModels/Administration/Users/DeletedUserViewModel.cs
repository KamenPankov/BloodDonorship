using System;

using BloodDonorship.Data.Models;
using BloodDonorship.Services.Mapping;

namespace BloodDonorship.Web.ViewModels.Administration.Users
{
    public class DeletedUserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime DeletedOn { get; set; }

        public string UserName { get; set; }
    }
}
