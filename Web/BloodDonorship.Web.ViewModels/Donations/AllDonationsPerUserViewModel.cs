using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloodDonorship.Web.ViewModels.Donations
{
    public class AllDonationsPerUserViewModel
    {
        public TimeSpan? TimeFromLastDonation
        {
            get
            {
                if (this.Donations.Any())
                {
                    return DateTime.UtcNow - this.Donations.ToArray()[0].CreatedOn;
                }

                return DateTime.UtcNow - default(DateTime);
            }
        }

        public IEnumerable<DonationPerUserViewModel> Donations { get; set; }
    }
}
