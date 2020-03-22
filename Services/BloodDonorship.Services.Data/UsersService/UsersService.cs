﻿
using System;
using System.Collections.Generic;
using System.Linq;
using BloodDonorship.Data.Common.Repositories;
using BloodDonorship.Data.Models;
using BloodDonorship.Data.Models.Enums;
using BloodDonorship.Services.Mapping;
using BloodDonorship.Web.ViewModels.Users;
using Microsoft.EntityFrameworkCore;

namespace BloodDonorship.Services.Data.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> entityRepository;

        public UsersService(IDeletableEntityRepository<ApplicationUser> entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public IEnumerable<EligibleUserViewModel> GetEligibleDonors(string userId)
        {
            IEnumerable<ApplicationUser> query = this.entityRepository.All().AsEnumerable()
                .Where(u => u.Id != userId &&
                this.CompatableBloodTypes(u.Blood.BloodType, u.Blood.RhFactor)
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

            return compatableBloods[(bloodType.ToString(), rhFactor.ToString())];
        }
    }
}