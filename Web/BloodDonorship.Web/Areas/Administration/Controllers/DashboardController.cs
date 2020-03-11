using BloodDonorship.Services.Data;
using BloodDonorship.Services.Data.BloodsService;
using BloodDonorship.Web.Areas.Identity.Pages.Account.Manage;
using BloodDonorship.Web.ViewModels.Administration.Dashboard;

using Microsoft.AspNetCore.Mvc;

namespace BloodDonorship.Web.Areas.Administration.Controllers
{
    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;

        public DashboardController(ISettingsService settingsService)
        {
            this.settingsService = settingsService;            
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel { SettingsCount = this.settingsService.GetCount(), };
            return this.View(viewModel);
        }
    }
}
