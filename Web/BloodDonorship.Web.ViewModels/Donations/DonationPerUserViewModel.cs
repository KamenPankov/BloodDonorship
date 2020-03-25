using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

using AutoMapper;
using BloodDonorship.Data.Models;
using BloodDonorship.Services.Mapping;

namespace BloodDonorship.Web.ViewModels.Donations
{
    public class DonationPerUserViewModel : IMapFrom<Donation>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [Display(Name = "Date")]
        public DateTime CreatedOn { get; set; }

        public string Beneficient { get; set; }

        public string ImageTitle { get; set; }

        public byte[] ImageData { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Donation, DonationPerUserViewModel>()
                .ForMember(d => d.Beneficient, options =>
                options.MapFrom(s => s.Request.User.UserName));
        }
    }
}
