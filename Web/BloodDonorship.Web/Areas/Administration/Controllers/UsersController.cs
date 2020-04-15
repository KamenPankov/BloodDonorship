using System.Threading.Tasks;

using BloodDonorship.Services.Data.UsersService;
using BloodDonorship.Web.ViewModels.Administration.Users;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonorship.Web.Areas.Administration.Controllers
{
    public class UsersController : AdministrationController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public IActionResult AllDeleted()
        {
            DeletedUsersViewModel viewModel = new DeletedUsersViewModel()
            {
                DeletedUsers = this.usersService.GetAllUsersDeleted<DeletedUserViewModel>(),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> DeleteUser(string userId)
        {
            await this.usersService.DeleteUser(userId);

            this.TempData["InfoMessage"] = "User has been deleted successfully.";

            return this.RedirectToAction("Index", "Dashboard");
        }

        public async Task<IActionResult> UndeleteUser(string userId)
        {
            await this.usersService.UndeleteUser(userId);

            this.TempData["InfoMessage"] = "User has been restored successfully.";

            return this.RedirectToAction("Index", "Dashboard");
        }
    }
}
