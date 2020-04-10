using System;

using AutoMapper;
using BloodDonorship.Data.Models;
using BloodDonorship.Services.Mapping;

namespace BloodDonorship.Web.ViewModels.Administration.Dashboard
{
    public class NotificationViewModel : IMapFrom<Notification>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AnonymousEmail { get; set; }

        public string SenderId { get; set; }

        public string RecipientId { get; set; }

        public string RequestId { get; set; }

        public string NotificationType { get; set; }

        public string Content { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Notification, NotificationViewModel>()
                .ForMember(d => d.NotificationType, options => options.MapFrom(s => s.NotificationType.ToString()));
        }
    }
}
