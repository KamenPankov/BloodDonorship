using System.Linq;
using System.Threading.Tasks;

using BloodDonorship.Data.Models;
using BloodDonorship.Services.Data.NotificationsService;
using BloodDonorship.Services.Data.UsersService;
using BloodDonorship.Services.Messaging;
using BloodDonorship.Web.ViewModels.Administration.Notifications;
using BloodDonorship.Web.ViewModels.Notifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonorship.Web.Areas.Administration.Controllers
{
    public class NotificationsController : AdministrationController
    {
        private readonly INotificationsService notificationsService;
        private readonly IUsersService usersService;
        private readonly IEmailSender emailSender;
        private readonly UserManager<ApplicationUser> userManager;

        public NotificationsController(
            INotificationsService notificationsService,
            IUsersService usersService,
            IEmailSender emailSender,
            UserManager<ApplicationUser> userManager)
        {
            this.notificationsService = notificationsService;
            this.usersService = usersService;
            this.emailSender = emailSender;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult AllToAdmin()
        {
            AllNotificationsAdminViewModel viewModel = new AllNotificationsAdminViewModel()
            {
                Notifications = this.notificationsService.AllToAdmin<NotificationAdminViewModel>(),
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
        public async Task<IActionResult> Answer(AnswerViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Answer", viewModel.Email);
            }

            string recipientId = this.usersService.GetUserIdByEmail(viewModel.Email);

            if (string.IsNullOrEmpty(recipientId))
            {
                ApplicationUser recipient = await this.userManager.FindByNameAsync(viewModel.Email);

                recipientId = recipient.Id;

                viewModel.Email = recipient.Email;
            }

            ApplicationUser userAdmin = this.userManager.GetUsersInRoleAsync("Administrator").Result.FirstOrDefault();

            NotificationInputModel inputNotification = new NotificationInputModel()
            {
                SenderId = userAdmin.Id,
                RecipientId = recipientId,
                NotificationType = "Administrator",
                Content = viewModel.Content,
            };

            await this.notificationsService.AddAsync(inputNotification);

            string from = userAdmin.Email;
            string fromName = userAdmin.UserName;
            string to = viewModel.Email;
            string subject = "Answer from BloodDonorship";
            string content = viewModel.Content;

            await this.emailSender.SendEmailAsync(from, fromName, to, subject, content);

            this.TempData["InfoMessage"] = $"Message to {viewModel.Email} has been sent successfully.";

            return this.RedirectToAction("AllToAdmin");
        }

        public async Task<IActionResult> Delete(string notificationId)
        {
            await this.notificationsService.Delete(notificationId);

            return this.RedirectToAction("AllToAdmin");
        }
    }
}
