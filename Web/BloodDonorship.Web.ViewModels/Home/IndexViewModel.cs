using BloodDonorship.Common;
using System;
using System.Collections.Generic;
using System.Text;



namespace BloodDonorship.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        public IndexViewModel(int requestsCount, int currentPage)
        {
            this.TotalPages =
                 (int)Math.Ceiling((decimal)requestsCount / GlobalConstants.RequestsPerPage);
            this.CurrentPage = currentPage;
        }

        public string PageTitle { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public bool HasNextPage => this.CurrentPage < this.TotalPages;

        public bool HasPreviousPage => this.CurrentPage > 1;

        public IEnumerable<AllRequestViewModel> AllRequests { get; set; }
    }
}
