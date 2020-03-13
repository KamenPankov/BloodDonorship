using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BloodDonorship.Data.Models;
using BloodDonorship.Services.Mapping;

namespace BloodDonorship.Web.ViewModels.Home
{
    public class AllRequestViewModel : IMapFrom<Request>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string BloodType { get; set; }

        public string CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<BloodDonorship.Data.Models.Request, AllRequestViewModel>()
                .ForMember(d => d.BloodType, o => o.MapFrom(s =>
                string.Concat(s.User.Blood.BloodType, " ", s.User.Blood.RhFactor)));

            configuration.CreateMap<BloodDonorship.Data.Models.Request, AllRequestViewModel>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.User.UserName));
        }
    }


}
