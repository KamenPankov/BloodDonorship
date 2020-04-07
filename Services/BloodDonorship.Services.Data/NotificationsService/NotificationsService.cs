using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BloodDonorship.Data.Common.Repositories;
using BloodDonorship.Data.Models;
using BloodDonorship.Data.Models.Enums;
using BloodDonorship.Services.Mapping;
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
            bool isNotificationType =
                Enum.TryParse<NotificationType>(inputModel.NotificationType, out NotificationType result);

            if (!isNotificationType)
            {
                return;
            }

            Notification notification = new Notification()
            {
                SenderId = inputModel.SenderId,
                RecipientId = inputModel.RecipientId,
                RequestId = inputModel.RequestId,
                NotificationType = Enum.Parse<NotificationType>(inputModel.NotificationType),
                Content = inputModel.Content,
            };

            await this.entityRepository.AddAsync(notification);
            await this.entityRepository.SaveChangesAsync();
        }

        public IEnumerable<T> AllByUser<T>(string userId, int? count = null)
        {
            IQueryable<Notification> query = this.entityRepository.All()
                .Where(n => n.RecipientId == userId)
                .OrderByDescending(n => n.CreatedOn);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToArray();
        }

        public async Task Delete(string notificationId)
        {
            Notification notification = this.entityRepository.All()
                .FirstOrDefault(n => n.Id == notificationId);

            if (notification != null)
            {
                this.entityRepository.Delete(notification);
                await this.entityRepository.SaveChangesAsync();
            }
        }
    }
}
