using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using BloodDonorship.Data.Models;
using BloodDonorship.Services.Data.DonationsService;
using BloodDonorship.Services.Data.NotificationsService;
using BloodDonorship.Services.Data.RequestsService;
using BloodDonorship.Services.Messaging;
using BloodDonorship.Web.ViewModels.Donations;
using BloodDonorship.Web.ViewModels.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace BloodDonorship.Web.Controllers
{
    [Authorize]
    public class DonationsController : Controller
    {
        private readonly IDonationsService donationsService;
        private readonly IRequestsService requestsService;
        private readonly IEmailSender emailSender;
        private readonly INotificationsService notificationsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public DonationsController(
            IDonationsService donationsService,
            IRequestsService requestsService,
            IEmailSender emailSender,
            INotificationsService notificationsService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.donationsService = donationsService;
            this.requestsService = requestsService;
            this.emailSender = emailSender;
            this.notificationsService = notificationsService;
            this.userManager = userManager;
            this.signInManager = signInManager;
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

            await this.NotifyBeneficientAsync(viewModel.UserId, viewModel.RequestId);

            return this.RedirectToAction("Index", "Home");
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
        public async Task<IActionResult> All()
        {
            ApplicationUser user = await this.userManager.GetUserAsync(this.User);

            if (user == null || !this.signInManager.IsSignedIn(this.User))
            {
                return this.RedirectToAction("Index", "Home");
            }

            AllDonationsPerUserViewModel viewModel = new AllDonationsPerUserViewModel()
            {
                Donations = this.donationsService.AllByUser<DonationPerUserViewModel>(user.Id),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Delete(string donationId)
        {
            await this.donationsService.Delete(donationId);

            return this.RedirectToAction("All");
        }

        private async Task NotifyBeneficientAsync(string userId, string requestId)
        {
            ApplicationUser user = await this.userManager.FindByIdAsync(userId);
            string from = await this.userManager.GetEmailAsync(user);
            string fromName = user.UserName;

            string beneficienId = this.requestsService.GetUserId(requestId);
            ApplicationUser beneficient = await this.userManager.FindByIdAsync(beneficienId);
            string to = await this.userManager.GetEmailAsync(beneficient);

            string subject = $"Blood Donation from {fromName}";
            string content = $"{fromName} has made a blood donation for you! You can view the verification document in BloodDonorship.";

            NotificationInputModel inputModel = new NotificationInputModel()
            {
                SenderId = userId,
                RecipientId = beneficienId,
                RequestId = requestId,
                NotificationType = "Donation",
                Content = content,
            };

            await this.notificationsService.AddAsync(inputModel);

            await this.emailSender.SendEmailAsync(from, fromName, to, subject, content);
        }
    }
}
