using System.Globalization;

using AutoMapper;
using BloodDonorship.Common;
using BloodDonorship.Data.Models;
using BloodDonorship.Services.Mapping;

namespace BloodDonorship.Web.ViewModels.Notifications
{
    public class NotificationPerRecicpientViewModel : IMapFrom<Notification>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string CreatedOn { get; set; }

        public string SenderUserName { get; set; }

        public string Content { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Notification, NotificationPerRecicpientViewModel>()
                .ForMember(d => d.CreatedOn, options =>
                options.MapFrom(s => s.CreatedOn.ToString(GlobalConstants.DateFormat, CultureInfo.InvariantCulture)));
        }
    }
}
