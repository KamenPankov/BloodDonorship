using System;
using System.Collections.Generic;
using System.Text;



namespace BloodDonorship.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        public string PageTitle { get; set; }

        public IEnumerable<AllRequestViewModel> AllRequests { get; set; }
    }
}
