using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using BloodDonorship.Data.Common.Models;
using BloodDonorship.Data.Models.Enums;

namespace BloodDonorship.Data.Models
{
    public class Notification : BaseDeletableModel<string>
    {
        public Notification()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string SenderId { get; set; }

        public virtual ApplicationUser Sender { get; set; }

        public string RecipientId { get; set; }

        public virtual ApplicationUser Recipient { get; set; }

        public string RequestId { get; set; }

        public virtual Request Request { get; set; }

        public NotificationType NotificationType { get; set; }

        [MaxLength(1000)]
        public string Content { get; set; }
    }
}
