using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using BloodDonorship.Data.Common.Models;

namespace BloodDonorship.Data.Models
{
    public class Donation : BaseDeletableModel<string>
    {
        public Donation()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string ImageTitle { get; set; }

        [MaxLength(1024 * 1024 * 5)]
        public byte[] ImageData { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; } // Sender

        public string RequestId { get; set; }

        public virtual Request Request { get; set; }
    }
}
