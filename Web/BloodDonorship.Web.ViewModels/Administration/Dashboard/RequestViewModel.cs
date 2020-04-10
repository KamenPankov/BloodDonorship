using System;

using AutoMapper;
using BloodDonorship.Data.Models;
using BloodDonorship.Services.Mapping;

namespace BloodDonorship.Web.ViewModels.Administration.Dashboard
{
    public class RequestViewModel : IMapFrom<Request>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; } // requester

        public int DonationsCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Request, RequestViewModel>()
                .ForMember(d => d.DonationsCount, options => options.MapFrom(s => s.Donations.Count));
        }
    }
}
