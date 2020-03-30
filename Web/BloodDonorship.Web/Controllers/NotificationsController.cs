using BloodDonorship.Data.Models;
using BloodDonorship.Services.Data.NotificationsService;
using BloodDonorship.Web.ViewModels.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonorship.Web.Controllers
{
    [Authorize]
    public class NotificationsController : Controller
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
        public IActionResult All()
        {
            string userId = this.userManager.GetUserId(this.User);

            AllNotificationsPerRecipientViewModel viewModel = new AllNotificationsPerRecipientViewModel()
            {
                Notifications = this.notificationsService.AllByUser<NotificationPerRecicpientViewModel>(userId),
            };

            return this.View(viewModel);
        }
    }
}
