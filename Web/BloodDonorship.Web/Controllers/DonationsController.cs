
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using BloodDonorship.Data.Models;
using BloodDonorship.Services.Data.DonationsService;
using BloodDonorship.Services.Data.RequestsService;
using BloodDonorship.Web.ViewModels.Donations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonorship.Web.Controllers
{
    [Authorize]
    public class DonationsController : Controller
    {
        private readonly IDonationsService donationsService;
        private readonly IRequestsService requestsService;
        private readonly UserManager<ApplicationUser> userManager;

        public DonationsController(
            IDonationsService donationsService,
            IRequestsService requestsService,
            UserManager<ApplicationUser> userManager)
        {
            this.donationsService = donationsService;
            this.requestsService = requestsService;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Create(string requestId, string userId)
        {
            if (userId == this.userManager.GetUserId(this.User))
            {
                this.TempData["Message"] = "You cannot donate to yourself!";

                return this.RedirectToAction("Index", "Home");
            }

            DateTime lastDonationDate = this.donationsService.LastDonationDate(this.userManager.GetUserId(this.User));

            if (lastDonationDate != null && (DateTime.UtcNow - lastDonationDate).TotalDays < 60)
            {
                this.TempData["Message"] = "The time period betweem two donations must be at least two months!";

                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDonationViewModel viewModel)
        {
            if (viewModel.FormFile?.Length > 1024 * 1024 * 2)
            {
                this.ModelState.AddModelError("Error", "File size must be less than 2 Megabytes.");
            }

            string[] allowedExtensions = { ".jpg", ".jpeg", ".bmp", ".pdf" };

            if (!allowedExtensions.Any(e => (viewModel.FormFile?.FileName.ToLower().EndsWith(e)).GetValueOrDefault()))
            {
                this.ModelState.AddModelError("Error", $"Allowed file formats are: {string.Join(", ", allowedExtensions)}.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            string fileName = "Verification_Document";
            string fileExtension = Path.GetExtension(viewModel.FormFile.FileName).ToLower();

            viewModel.FileName = string.Concat(fileName, fileExtension);

            await this.donationsService.AddAsync(viewModel);

            this.TempData["Success"] = 
                $"Successfully donated to {await this.userManager.FindByIdAsync(this.requestsService.GetUserId(viewModel.RequestId))}!";

            return this.RedirectToAction("Index", "Home");
        }

    }
}
