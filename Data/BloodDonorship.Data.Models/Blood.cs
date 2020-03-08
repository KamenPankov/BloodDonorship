using System;
using System.Collections.Generic;
using System.Text;

using BloodDonorship.Data.Common.Models;
using BloodDonorship.Data.Models.Enums;

namespace BloodDonorship.Data.Models
{
    public class Blood : BaseModel<int>
    {
        public Blood()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        public BloodType BloodType { get; set; }

        public RhFactor RhFactor { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
