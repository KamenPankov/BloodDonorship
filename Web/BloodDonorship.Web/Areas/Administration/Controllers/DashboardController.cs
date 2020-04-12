using BloodDonorship.Services.Data;
using BloodDonorship.Services.Data.BloodsService;
using BloodDonorship.Services.Data.UsersService;
using BloodDonorship.Web.Areas.Identity.Pages.Account.Manage;
using BloodDonorship.Web.ViewModels.Administration.Dashboard;

using Microsoft.AspNetCore.Mvc;

namespace BloodDonorship.Web.Areas.Administration.Controllers
{
    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;
        private readonly IUsersService usersService;

        public DashboardController(
            ISettingsService settingsService,
            IUsersService usersService)
        {
            this.settingsService = settingsService;
            this.usersService = usersService;
        }

        public IActionResult Index()
        {
            IndexViewModel viewModel = new IndexViewModel()
            {
                Users = this.usersService.GetAllUsers<UserViewModel>(), // TODO: get all with deleted
            };

            viewModel.MostWantedBloodType = this.usersService.MostWantedBloodType();
            viewModel.MostDonatedBloodType = this.usersService.MostDonatedBloodType();
            viewModel.AvailableDonors = this.usersService.AvailableDonors();

            return this.View(viewModel);
        }
    }
}
