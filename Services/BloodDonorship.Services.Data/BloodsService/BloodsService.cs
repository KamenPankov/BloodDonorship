using System;
using System.Collections.Generic;
using System.Linq;

using BloodDonorship.Data.Common.Repositories;
using BloodDonorship.Data.Models;
using BloodDonorship.Data.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodDonorship.Services.Data.BloodsService
{
    public class BloodsService : IBloodsService
    {
        private readonly IRepository<Blood> bloodRepository;

        public BloodsService(IRepository<Blood> bloodRepository)
        {
            this.bloodRepository = bloodRepository;
        }

        public Blood GetBlood(string bloodType, string rhFactor)
        {
            return this.bloodRepository.All().AsEnumerable<Blood>()
                .Where(b => b.BloodType.ToString() == bloodType && b.RhFactor.ToString() == rhFactor)
                .FirstOrDefault();
        }

        public IEnumerable<SelectListItem> BloodTypes()
        {
            List<SelectListItem> bloodTypes = new List<SelectListItem>();

            foreach (string bloodType in Enum.GetNames(typeof(BloodType)))
            {
                SelectListItem listItem = new SelectListItem()
                {
                    Text = bloodType,
                    Value = bloodType,
                };

                bloodTypes.Add(listItem);
            }

            return bloodTypes;
        }


        public IEnumerable<SelectListItem> RhFactors()
        {
            List<SelectListItem> rhFactors = new List<SelectListItem>();

            foreach (string rhFactor in Enum.GetNames(typeof(RhFactor)))
            {
                SelectListItem listItem = new SelectListItem()
                {
                    Text = rhFactor,
                    Value = rhFactor,
                };

                rhFactors.Add(listItem);
            }

            return rhFactors;
        }

        public string GetBloodType(int bloodId)
        {
            return this.bloodRepository.All().AsEnumerable<Blood>()
                .Where(b => b.Id == bloodId)
                .Select(b => b.BloodType.ToString())
                .FirstOrDefault();
        }

        public string GetRhFactor(int bloodId)
        {
            return this.bloodRepository.All().AsEnumerable<Blood>()
                .Where(b => b.Id == bloodId)
                .Select(b => b.RhFactor.ToString())
                .FirstOrDefault();
        }
    }
}
