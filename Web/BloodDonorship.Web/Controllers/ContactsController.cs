using System.Linq;
using System.Threading.Tasks;

using BloodDonorship.Data.Models;
using BloodDonorship.Services.Data.NotificationsService;
using BloodDonorship.Services.Data.UsersService;
using BloodDonorship.Services.Messaging;
using BloodDonorship.Web.ViewModels.Contacts;
using BloodDonorship.Web.ViewModels.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonorship.Web.Controllers
{
    [AllowAnonymous]
    public class ContactsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly INotificationsService notificationsService;
        private readonly IEmailSender emailSender;
        private readonly IUsersService usersService;

        public ContactsController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            INotificationsService notificationsService,
            IEmailSender emailSender,
            IUsersService usersService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.notificationsService = notificationsService;
            this.emailSender = emailSender;
            this.usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (this.signInManager.IsSignedIn(this.User))
            {
                ApplicationUser user = await this.userManager.GetUserAsync(this.User);

                CreateContactInputModel inputModel = new CreateContactInputModel()
                {
                    UserEmail = user.Email,
                };

                return this.View(inputModel);
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Create", inputModel);
            }

            ApplicationUser userAdmin = this.userManager.GetUsersInRoleAsync("Administrator").Result.FirstOrDefault();
            string senderId = string.Empty;

            bool isSignedIn = this.signInManager.IsSignedIn(this.User);

            if (isSignedIn)
            {
                senderId = this.userManager.GetUserId(this.User);
            }
            else
            {
                senderId = await this.usersService.AddAnonymousUser(inputModel.UserEmail);
            }

            NotificationInputModel inputNotification = new NotificationInputModel()
            {
                AnonymousEmail = isSignedIn ? string.Empty : inputModel.UserEmail,
                SenderId = senderId,
                RecipientId = userAdmin.Id,
                NotificationType = "Administrator",
                Content = inputModel.Content,
            };

            await this.notificationsService.AddAsync(inputNotification);

            string from = inputModel.UserEmail;
            string to = userAdmin.Email;
            string subject = !isSignedIn ?
                $"Anonymous from: {inputModel.UserEmail}" :
                inputModel.UserEmail;
            string content = inputModel.Content;

            await this.emailSender.SendEmailAsync(from, from, to, subject, content);

            this.TempData["InfoMessage"] = "Message has been sent successfully.";

            return this.RedirectToAction("Create");
        }
    }
}
