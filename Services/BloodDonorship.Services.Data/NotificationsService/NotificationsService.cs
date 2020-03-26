using System.Threading.Tasks;

using BloodDonorship.Data.Common.Repositories;
using BloodDonorship.Data.Models;
using BloodDonorship.Web.ViewModels.Notifications;

namespace BloodDonorship.Services.Data.NotificationsService
{
    public class NotificationsService : INotificationsService
    {
        private readonly IDeletableEntityRepository<Notification> entityRepository;

        public NotificationsService(IDeletableEntityRepository<Notification> entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public async Task AddAsync(NotificationInputModel inputModel)
        {
            Notification notification = new Notification()
            {
                SenderId = inputModel.SenderId,
                RecipientId = inputModel.RecipientId,
                RequestId = inputModel.RequestId,
                Content = inputModel.Content,
            };

            await this.entityRepository.AddAsync(notification);
            await this.entityRepository.SaveChangesAsync();
        }
    }
}
