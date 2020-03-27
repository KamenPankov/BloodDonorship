using System;
using System.Diagnostics;
using System.Threading.Tasks;

using BloodDonorship.Common;
using BloodDonorship.Data.Models;
using BloodDonorship.Services.Data.RequestsService;
using BloodDonorship.Web.ViewModels;
using BloodDonorship.Web.ViewModels.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonorship.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IRequestsService requestsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public HomeController(
            IRequestsService requestsService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.requestsService = requestsService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? currentPage, string email = null)
        {
            ApplicationUser user = await this.userManager.GetUserAsync(this.User);

            if (this.signInManager.IsSignedIn(this.User))
            {
                if (!currentPage.HasValue)
                {
                    currentPage = 1;
                }

                int requestsCount = this.requestsService.RequestsCount();

                IndexViewModel viewModel = new IndexViewModel(requestsCount, currentPage.Value)
                {
                    PageTitle = string.IsNullOrEmpty(email) ?
                                    "All Requests" :
                                    $"Results for: {email}",
                    AllRequests = string.IsNullOrEmpty(email) ?
                                    this.requestsService.All<AllRequestViewModel>
                                        (currentPage.Value, GlobalConstants.RequestsPerPage) :
                                    this.requestsService.AllByEmail<AllRequestViewModel>(email),
                };

                return this.View(viewModel);
            }

            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
