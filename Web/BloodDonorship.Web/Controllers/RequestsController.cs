using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BloodDonorship.Data.Models;
using BloodDonorship.Services.Data.DonationsService;
using BloodDonorship.Services.Data.RequestsService;
using BloodDonorship.Services.Data.UsersService;
using BloodDonorship.Services.Messaging;
using BloodDonorship.Web.ViewModels.Requests;
using BloodDonorship.Web.ViewModels.Users;
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
        private readonly IUsersService usersService;
        private readonly IEmailSender emailSender;

        public RequestsController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IRequestsService requestsService,
            IDonationsService donationsService,
            IUsersService usersService,
            IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.requestsService = requestsService;
            this.donationsService = donationsService;
            this.usersService = usersService;
            this.emailSender = emailSender;
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

            IEnumerable<EligibleUserViewModel> eligibleUsers =
                this.usersService.GetEligibleDonors(user);

            await this.requestsService.Add(user.Id, eligibleUsers.Count());

            await this.NotifyEligibleDonorsAsync(eligibleUsers, user);

            return this.RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Details(string requestId)
        {
            DetailsRequestViewModel viewModel = new DetailsRequestViewModel()
            {
                Id = requestId,
                Donations = this.donationsService
                .AllByRequest<DonationInDetailsRequestViewModel>(requestId),
            };

            return this.View(viewModel.Donations);
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

        private async Task NotifyEligibleDonorsAsync(IEnumerable<EligibleUserViewModel> eligibleUsers, ApplicationUser user)
        {
            string from = await this.userManager.GetEmailAsync(user);
            string fromName = await this.userManager.GetUserNameAsync(user);
            string subject = $"Blood Request from {fromName}";
            string content = $"{fromName} has made a blood request. You can make a donation for him.";

            foreach (EligibleUserViewModel donor in eligibleUsers)
            {
                await this.emailSender.SendEmailAsync(from, fromName, donor.Email, subject, content);
            }
        }
    }
}
