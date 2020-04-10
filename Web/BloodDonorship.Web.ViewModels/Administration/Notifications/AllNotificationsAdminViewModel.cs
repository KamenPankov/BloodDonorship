using System.Collections.Generic;
using System.Text;

namespace BloodDonorship.Web.ViewModels.Administration.Notifications
{
    public class AllNotificationsAdminViewModel
    {
        public IEnumerable<NotificationAdminViewModel> Notifications { get; set; }
    }
}
