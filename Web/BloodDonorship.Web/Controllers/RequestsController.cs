using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BloodDonorship.Data.Models;
using BloodDonorship.Services.Data.DonationsService;
using BloodDonorship.Services.Data.RequestsService;
using BloodDonorship.Web.ViewModels.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace BloodDonorship.Web.Controllers
{
    [Authorize]
    public class RequestsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IRequestsService requestsService;
        private readonly IDonationsService donationsService;

        public RequestsController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IRequestsService requestsService,
            IDonationsService donationsService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.requestsService = requestsService;
            this.donationsService = donationsService;
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

        [HttpGet]
        public IActionResult Details(string requestId)
        {
            DetailsRequestViewModel viewModel = new DetailsRequestViewModel()
            {
                Id = requestId,
                Donations = this.donationsService
                .GetDonationsPerRequest<DonationInDetailsRequestViewModel>(requestId),
            };

            return this.View(viewModel.Donations);
        }

        [HttpGet]
        public FileResult Download(string donationId)
        {
            byte[] fileContent = this.donationsService.FileContent(donationId);
            new FileExtensionContentTypeProvider()
                .TryGetContentType(this.donationsService.FileType(donationId), out string mimeType);

            return this.File(fileContent, mimeType);
        }

        [HttpGet]
        public IActionResult Delete(string requestId)
        {
            this.TempData["DeleteMessage"] = "You are about to delete the request. It will no longer be seen by potential donors!";

            DeleteRequestViewModel viewModel = new DeleteRequestViewModel()
            {
                Id = requestId,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteRequestViewModel viewModel)
        {
            await this.requestsService.Delete(viewModel.Id);

            return this.RedirectToAction("All");
        }
    }
}
