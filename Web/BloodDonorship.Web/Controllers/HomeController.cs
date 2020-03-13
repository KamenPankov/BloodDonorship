using System.Diagnostics;
using System.Threading.Tasks;
using BloodDonorship.Data.Models;
using BloodDonorship.Services.Data.RequestsService;
using BloodDonorship.Web.ViewModels;
using BloodDonorship.Web.ViewModels.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonorship.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IRequestsService requestsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public HomeController(IRequestsService requestsService, 
                              UserManager<ApplicationUser> userManager, 
                              SignInManager<ApplicationUser> signInManager)
        {
            this.requestsService = requestsService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await this.userManager.GetUserAsync(this.User);

            if (this.signInManager.IsSignedIn(this.User))
            {
                IndexViewModel viewModel = new IndexViewModel()
                {
                    AllRequests = this.requestsService.All<AllRequestViewModel>(),
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
