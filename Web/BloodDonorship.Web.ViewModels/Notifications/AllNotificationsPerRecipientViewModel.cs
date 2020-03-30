using System.Collections.Generic;
using System.Globalization;

using AutoMapper;
using BloodDonorship.Common;
using BloodDonorship.Data.Models;
using BloodDonorship.Services.Mapping;

namespace BloodDonorship.Web.ViewModels.Notifications
{

    public class AllNotificationsPerRecipientViewModel
    {
        public IEnumerable<NotificationPerRecicpientViewModel> Notifications { get; set; }
    }
}
