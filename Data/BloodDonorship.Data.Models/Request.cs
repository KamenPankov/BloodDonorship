using System;
using System.Collections.Generic;
using System.Text;

using BloodDonorship.Data.Common.Models;

namespace BloodDonorship.Data.Models
{
    public class Request : BaseDeletableModel<string>
    {
        public Request()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Donations = new HashSet<Donation>();
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; } // Requester

        public virtual ICollection<Donation> Donations { get; set; }
    }
}
