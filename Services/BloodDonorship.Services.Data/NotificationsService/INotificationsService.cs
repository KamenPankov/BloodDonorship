using System.Threading.Tasks;

using BloodDonorship.Web.ViewModels.Notifications;

namespace BloodDonorship.Services.Data.NotificationsService
{
    public interface INotificationsService
    {
        Task AddAsync(NotificationInputModel inputModel);
    }
}
