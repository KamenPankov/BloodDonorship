using System;
using System.Collections.Generic;
using System.Linq;

using BloodDonorship.Data.Common.Repositories;
using BloodDonorship.Data.Models;
using BloodDonorship.Data.Models.Enums;
using BloodDonorship.Web.ViewModels.Users;

namespace BloodDonorship.Services.Data.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> entityRepository;

        public UsersService(IDeletableEntityRepository<ApplicationUser> entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public string GetUserIdByEmail(string email)
        {
            return this.entityRepository.All()
                .Where(u => u.Email == email)
                .Select(u => u.Id)
                .FirstOrDefault();
        }

        public IEnumerable<EligibleUserViewModel> GetEligibleDonors(ApplicationUser user)
        {
            IEnumerable<(string BloodGroup, string RhFactor)> eligibleBloodTypes;
            if (user.Blood != null)
            {
                eligibleBloodTypes =
                this.CompatableBloodTypes(user.Blood.BloodType, user.Blood.RhFactor);
            }
            else
            {
                eligibleBloodTypes = new List<(string, string)>();
            }

            IEnumerable<ApplicationUser> query = this.entityRepository.All().AsEnumerable()
                .Where(u => u.Id != user.Id && u.Blood != null &&
                eligibleBloodTypes
                .Any(b => (b.BloodGroup == u.Blood.BloodType.ToString() && b.RhFactor == u.Blood.RhFactor.ToString())) &&
                (DateTime.UtcNow - u.Donations
                    .OrderByDescending(d => d.CreatedOn)
                    .Select(d => d.CreatedOn)
                    .FirstOrDefault()).TotalDays >= 60);

            return query.Select(u => new EligibleUserViewModel()
            {
                Id = u.Id,
                Email = u.Email,
            }).ToArray();
        }

        private IEnumerable<(string BloodGroup, string RhFactor)> CompatableBloodTypes(BloodType bloodType, RhFactor rhFactor)
        {
            Dictionary<(string, string), List<(string, string)>> compatableBloods =
                new Dictionary<(string, string), List<(string, string)>>()
                {
                    [("A", "Positive")] = new List<(string, string)>()
                    {
                        ("A", "Positive"),
                        ("A", "Negative"),
                        ("O", "Positive"),
                        ("O", "Negative"),
                    },
                    [("A", "Negative")] = new List<(string, string)>()
                    {
                        ("A", "Negative"),
                        ("O", "Negative"),
                    },
                    [("B", "Positive")] = new List<(string, string)>()
                    {
                        ("B", "Positive"),
                        ("B", "Negative"),
                        ("O", "Positive"),
                        ("O", "Negative"),
                    },
                    [("B", "Negative")] = new List<(string, string)>()
                    {
                        ("B", "Negative"),
                        ("O", "Negative"),
                    },
                    [("AB", "Positive")] = new List<(string, string)>()
                    {
                        ("A", "Positive"),
                        ("A", "Negative"),
                        ("B", "Positive"),
                        ("B", "Negative"),
                        ("O", "Positive"),
                        ("O", "Negative"),
                        ("AB", "Positive"),
                        ("AB", "Negative"),
                    },
                    [("AB", "Negative")] = new List<(string, string)>()
                    {
                        ("A", "Negative"),
                        ("B", "Negative"),
                        ("O", "Negative"),
                        ("AB", "Negative"),
                    },
                    [("O", "Positive")] = new List<(string, string)>()
                    {
                        ("O", "Positive"),
                        ("O", "Negative"),
                    },
                    [("O", "Negative")] = new List<(string, string)>()
                    {
                        ("O", "Negative"),
                    },
                };
            List<(string, string)> resultBloods = compatableBloods[(bloodType.ToString(), rhFactor.ToString())];
            return resultBloods;
        }
    }
}
