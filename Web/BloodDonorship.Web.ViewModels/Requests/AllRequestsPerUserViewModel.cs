using System;
using System.Collections.Generic;
using System.Text;

using BloodDonorship.Data.Models;
using BloodDonorship.Services.Mapping;

namespace BloodDonorship.Web.ViewModels.Requests
{
    public class AllRequestsPerUserViewModel : IMapFrom<Request>
    {
        public string CreatedOn { get; set; }
    }
}
