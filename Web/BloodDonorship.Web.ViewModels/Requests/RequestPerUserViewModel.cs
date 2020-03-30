using System.ComponentModel.DataAnnotations;
using System.Globalization;
using AutoMapper;
using BloodDonorship.Common;
using BloodDonorship.Data.Models;
using BloodDonorship.Services.Mapping;

namespace BloodDonorship.Web.ViewModels.Requests
{
    public class RequestPerUserViewModel : IMapFrom<Request>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [Display(Name = "Created On")]
        public string CreatedOn { get; set; }

        [Display(Name = "Notified People")]
        public int NotifiedUsersCount { get; set; }

        public int DonationsCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<BloodDonorship.Data.Models.Request, RequestPerUserViewModel>()
                .ForMember(d => d.CreatedOn, o =>
                    o.MapFrom(s => s.CreatedOn.ToString(GlobalConstants.DateFormat, CultureInfo.InvariantCulture)));
        }
    }
}
