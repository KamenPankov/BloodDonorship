using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BloodDonorship.Data.Models;
using BloodDonorship.Services.Data.RequestsService;
using BloodDonorship.Web.ViewModels.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonorship.Web.Controllers
{
    [Authorize]
    public class RequestsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IRequestsService requestsService;

        public RequestsController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IRequestsService requestsService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.requestsService = requestsService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            ApplicationUser user = await this.userManager.GetUserAsync(this.User);

            if (user == null || !this.signInManager.IsSignedIn(this.User))
            {
                return this.RedirectToAction("Index", "Home");
            }

            IEnumerable<AllRequestsPerUserViewModel> requests = 
                this.requestsService.AllByUser<AllRequestsPerUserViewModel>(user.Id);

            return this.View(requests);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ApplicationUser user = await this.userManager.GetUserAsync(this.User);

            if (user == null || !this.signInManager.IsSignedIn(this.User))
            {
                return this.RedirectToAction("Index", "Home");
            }

            await this.requestsService.Add(user.Id);

            return this.RedirectToAction("All");
        }
    }
}
