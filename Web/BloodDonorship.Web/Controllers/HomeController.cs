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
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(
            IRequestsService requestsService,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            this.requestsService = requestsService;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index(int? currentPage, string email = null)
        {
            if (this.signInManager.IsSignedIn(this.User))
            {
                if (!currentPage.HasValue || currentPage.Value < 1)
                {
                    currentPage = 1;
                }

                int requestsCount = this.requestsService.RequestsCount();

                int lastPage = (int)Math.Ceiling((decimal)requestsCount / GlobalConstants.RequestsPerPage);

                if (currentPage > lastPage)
                {
                    currentPage = lastPage;
                }

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
