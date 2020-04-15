using System.Linq;
using System.Threading.Tasks;

using BloodDonorship.Data.Models;
using BloodDonorship.Services.Data.NotificationsService;
using BloodDonorship.Services.Data.UsersService;
using BloodDonorship.Services.Messaging;
using BloodDonorship.Web.ViewModels.Administration.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonorship.Web.Areas.Administration.Controllers
{
    public class UsersController : AdministrationController
    {
        private readonly IUsersService usersService;
        private readonly IEmailSender emailSender;
        private readonly INotificationsService notificationsService;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(
            IUsersService usersService,
            IEmailSender emailSender,
            UserManager<ApplicationUser> userManager)
        {
            this.usersService = usersService;
            this.emailSender = emailSender;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult AllDeleted()
        {
            DeletedUsersViewModel viewModel = new DeletedUsersViewModel()
            {
                DeletedUsers = this.usersService.GetAllUsersDeleted<DeletedUserViewModel>(),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> DeleteUser(string userId)
        {
            await this.usersService.DeleteUser(userId);

            await this.NotifyUser(userId);

            this.TempData["InfoMessage"] = "User has been deleted successfully.";

            return this.RedirectToAction("Index", "Dashboard");
        }

        public async Task<IActionResult> UndeleteUser(string userId)
        {
            await this.usersService.UndeleteUser(userId);

            await this.NotifyUser(userId);

            this.TempData["InfoMessage"] = "User has been restored successfully.";

            return this.RedirectToAction("Index", "Dashboard");
        }

        private async Task NotifyUser(string userId)
        {
            ApplicationUser userAdmin = this.userManager.GetUsersInRoleAsync("Administrator").Result.FirstOrDefault();
            ApplicationUser user = await this.userManager.FindByIdAsync(userId);

            string from = userAdmin.Email;
            string fromName = userAdmin.UserName;
            string to = user.Email;
            string subject = "BloodDonorship";
            string content = user.IsDeleted ?
                "You have been restored. You can make blood requests and donations."
                : "You have been banned. You will no longer be able to make blood requests and donations.";

            await this.emailSender.SendEmailAsync(from, fromName, to, subject, content);
        }
    }
}
