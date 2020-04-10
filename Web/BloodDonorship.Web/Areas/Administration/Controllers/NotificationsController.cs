using System;
using BloodDonorship.Data.Models;
using BloodDonorship.Services.Data.NotificationsService;
using BloodDonorship.Web.ViewModels.Administration.Notifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonorship.Web.Areas.Administration.Controllers
{
    public class NotificationsController : AdministrationController
    {
        private readonly INotificationsService notificationsService;
        private readonly UserManager<ApplicationUser> userManager;

        public NotificationsController(
            INotificationsService notificationsService,
            UserManager<ApplicationUser> userManager)
        {
            this.notificationsService = notificationsService;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult AllToAdmin()
        {
            string adminId = this.userManager.GetUserId(this.User);

            AllNotificationsAdminViewModel viewModel = new AllNotificationsAdminViewModel()
            {
                Notifications = this.notificationsService.AllByUser<NotificationAdminViewModel>(adminId),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Answer(string email)
        {
            AnswerViewModel viewModel = new AnswerViewModel()
            {
                Email = email,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Answer(AnswerViewModel viewModel)
        {
            // TODO: create notification

            // TODO: sned email

            return this.RedirectToAction("AllToAdmin");
        }
    }
}
