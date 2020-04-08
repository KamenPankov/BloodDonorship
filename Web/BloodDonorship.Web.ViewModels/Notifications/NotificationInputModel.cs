using System.ComponentModel.DataAnnotations;

namespace BloodDonorship.Web.ViewModels.Notifications
{
    public class NotificationInputModel
    {
        public string AnonymousEmail { get; set; }

        public string SenderId { get; set; }

        public string RecipientId { get; set; }

        public string RequestId { get; set; }

        public string NotificationType { get; set; }

        [MaxLength(1000)]
        public string Content { get; set; }
    }
}
