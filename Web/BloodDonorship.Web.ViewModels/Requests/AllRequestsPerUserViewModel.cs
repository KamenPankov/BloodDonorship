using System;
using System.Collections.Generic;
using System.Text;

namespace BloodDonorship.Web.ViewModels.Requests
{
    public class AllRequestsPerUserViewModel
    {
        public IEnumerable<RequestPerUserViewModel> Requests { get; set; }
    }
}
