// ReSharper disable VirtualMemberCallInConstructor
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using BloodDonorship.Data.Common.Models;

using Microsoft.AspNetCore.Identity;

namespace BloodDonorship.Data.Models
{
    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();

            this.Requests = new HashSet<Request>();
            this.Donations = new HashSet<Donation>();
            this.Senders = new HashSet<Notification>();
            this.Recipients = new HashSet<Notification>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int? BloodId { get; set; }

        public virtual Blood Blood { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Request> Requests { get; set; }

        public virtual ICollection<Donation> Donations { get; set; }

        [InverseProperty("Sender")]
        public virtual ICollection<Notification> Senders { get; set; }

        [InverseProperty("Recipient")]
        public virtual ICollection<Notification> Recipients { get; set; }
    }
}
