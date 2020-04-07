using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BloodDonorship.Data;
using BloodDonorship.Data.Common.Repositories;
using BloodDonorship.Data.Models;
using BloodDonorship.Data.Repositories;
using BloodDonorship.Services.Data.NotificationsService;
using BloodDonorship.Services.Mapping;
using BloodDonorship.Web.ViewModels.Notifications;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BloodDonorship.Services.Data.Tests
{
    public class NotificationsServicesTests
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IDeletableEntityRepository<Notification> notificationRepository;
        private readonly INotificationsService notificationsService;

        public NotificationsServicesTests()
        {
            DbContextOptionsBuilder<ApplicationDbContext> options =
                new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            this.applicationDbContext = new ApplicationDbContext(options.Options);

            this.notificationRepository = new EfDeletableEntityRepository<Notification>(this.applicationDbContext);

            this.notificationsService = new NotificationsService.NotificationsService(this.notificationRepository);

            foreach (Notification notification in this.GetTestNotifications())
            {
                this.notificationRepository.AddAsync(notification);
                this.notificationRepository.SaveChangesAsync();
            }
        }

        public string NotificationSevenId { get; set; }

        public IEnumerable<Notification> GetTestNotifications()
        {
            List<Notification> notifications = new List<Notification>();

            for (int i = 0; i < 10; i++)
            {
                Notification notification = new Notification()
                {
                    Recipient = new ApplicationUser(),
                };

                if (i == 7)
                {
                    this.NotificationSevenId = notification.Id;
                }

                notifications.Add(notification);
            }

            return notifications;
        }

        [Fact]
        public void NotificationsAllByUserRetutnRightTest()
        {
            ApplicationUser user = new ApplicationUser();

            for (int i = 0; i < 5; i++)
            {
                this.notificationRepository.AddAsync(new Notification()
                {
                    Recipient = user,
                });
            }

            this.notificationRepository.SaveChangesAsync();

            AutoMapperConfig.RegisterMappings(typeof(NotificationTestModel).Assembly);

            IEnumerable<NotificationTestModel> notificationsByUser =
                this.notificationsService.AllByUser<NotificationTestModel>(user.Id);

            Assert.True(notificationsByUser.Count() == 5);
        }

        [Fact]
        public void NotificationsAllByUserRetutnEmptyCollectionTest()
        {
            ApplicationUser user = new ApplicationUser();

            AutoMapperConfig.RegisterMappings(typeof(NotificationTestModel).Assembly);

            IEnumerable<NotificationTestModel> notificationsByUser =
                this.notificationsService.AllByUser<NotificationTestModel>(user.Id);

            Assert.True(notificationsByUser.Count() == 0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NotificationsAllByUserRetutnEmptyCollectionWrongInputTest(string userId)
        {
            AutoMapperConfig.RegisterMappings(typeof(NotificationTestModel).Assembly);

            IEnumerable<NotificationTestModel> notificationsByUser =
                this.notificationsService.AllByUser<NotificationTestModel>(userId);

            Assert.True(notificationsByUser.Count() == 0);
        }

        [Fact]
        public void NotificationsDeleteRightInputTest()
        {
            Notification notification = new Notification();

            this.notificationRepository.AddAsync(notification);
            this.notificationRepository.SaveChangesAsync();

            this.notificationsService.Delete(notification.Id);

            this.notificationsService.Delete(this.NotificationSevenId);

            Assert.True(this.notificationRepository.All().Count() == 9);
        }

        [Fact]
        public void NotificationsDeleteWrongInputTest()
        {
            this.notificationsService.Delete(Guid.NewGuid().ToString());

            Assert.True(this.notificationRepository.All().Count() == 10);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NotificationsDeleteNullInputTest(string notificationId)
        {
            this.notificationsService.Delete(notificationId);

            Assert.True(this.notificationRepository.All().Count() == 10);
        }

        [Fact]
        public async Task NotificationsAddAsyncRightInputTest()
        {
            await this.notificationsService.AddAsync(new NotificationInputModel()
            {
                NotificationType = "Request",
            });

            Assert.True(this.notificationRepository.All().Count() == 11);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Something")]
        public async Task NotificationsAddAsyncWrongInputTest(string notificationsType)
        {
            await this.notificationsService.AddAsync(new NotificationInputModel()
            {
                NotificationType = notificationsType,
            });

            Assert.True(this.notificationRepository.All().Count() == 10);
        }

        public class NotificationTestModel : IMapFrom<Notification>
        {
        }
    }
}
