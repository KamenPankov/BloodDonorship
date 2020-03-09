using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using BloodDonorship.Data.Common.Models;

namespace BloodDonorship.Data.Models
{
    public class Notification : BaseDeletableModel<string>
    {
        public Notification()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string SenderId { get; set; }

        public ApplicationUser Sender { get; set; }

        public string RecipientId { get; set; }

        public ApplicationUser Recipient { get; set; }

        public string RequestId { get; set; }

        public Request Request { get; set; }

        [MaxLength(1000)]
        public string Content { get; set; }
    }
}
