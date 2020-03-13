using System;
using System.Collections.Generic;
using System.Text;



namespace BloodDonorship.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        public IEnumerable<AllRequestViewModel> AllRequests { get; set; }
    }
}
