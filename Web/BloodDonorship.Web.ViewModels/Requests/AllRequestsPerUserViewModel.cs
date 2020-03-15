using AutoMapper;
using BloodDonorship.Data.Models;
using BloodDonorship.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace BloodDonorship.Web.ViewModels.Requests
{
    public class AllRequestsPerUserViewModel : IMapFrom<Request>, IHaveCustomMappings
    {
        [Display(Name = "Created On")]
        public string CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<BloodDonorship.Data.Models.Request, AllRequestsPerUserViewModel>()
                .ForMember(c => c.CreatedOn, o => o.MapFrom(s => s.CreatedOn.ToString("dd-MMM-yyyy hh:mm")));
        }
    }
}
