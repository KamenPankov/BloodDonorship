using System.Collections.Generic;

namespace BloodDonorship.Web.ViewModels.Administration.Users
{
    public class DeletedUsersViewModel
    {
        public IEnumerable<DeletedUserViewModel> DeletedUsers { get; set; }
    }
}
