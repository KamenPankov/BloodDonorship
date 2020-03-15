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

        public string UserBloodBloodType { get; set; }

        public string UserBloodRhFactor { get; set; }

        public string CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<BloodDonorship.Data.Models.Request, AllRequestViewModel>()
                .ForMember(d => d.UserBloodBloodType, o => o.MapFrom(s =>
                s.User.Blood.BloodType.ToString()));

            configuration.CreateMap<BloodDonorship.Data.Models.Request, AllRequestViewModel>()
                .ForMember(d => d.UserBloodBloodType, o => o.MapFrom(s =>
                s.User.Blood.RhFactor.ToString()));

            configuration.CreateMap<BloodDonorship.Data.Models.Request, AllRequestViewModel>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.User.UserName));
        }
    }


}
