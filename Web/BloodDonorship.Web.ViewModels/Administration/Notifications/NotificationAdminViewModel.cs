using System;
using System.ComponentModel.DataAnnotations;

using AutoMapper;
using BloodDonorship.Data.Models;
using BloodDonorship.Services.Mapping;

namespace BloodDonorship.Web.ViewModels.Administration.Notifications
{
    public class NotificationAdminViewModel : IMapFrom<Notification>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [Display(Name = "Received On")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "From")]
        public string SenderUserName { get; set; }

        public string AnonymousEmail { get; set; }

        public string NotificationType { get; set; }

        public string Content { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Notification, NotificationAdminViewModel>()
                .ForMember(d => d.NotificationType, options =>
                options.MapFrom(s => s.NotificationType.ToString()));
        }
    }
}
