using System.Collections.Generic;
using System.Threading.Tasks;

using BloodDonorship.Web.ViewModels.Notifications;

namespace BloodDonorship.Services.Data.NotificationsService
{
    public interface INotificationsService
    {
        Task AddAsync(NotificationInputModel inputModel);

        IEnumerable<T> AllByUser<T>(string userId, int? count = null);

        Task Delete(string notificationId);
    }
}
