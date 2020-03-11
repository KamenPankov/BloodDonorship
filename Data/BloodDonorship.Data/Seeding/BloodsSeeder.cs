using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BloodDonorship.Data.Models;
using BloodDonorship.Data.Models.Enums;

namespace BloodDonorship.Data.Seeding
{
    public class BloodsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Bloods.Any())
            {
                return;
            }

            string[] bloodTypes = { "A", "B", "AB", "O" };

            List<Blood> bloods = new List<Blood>();

            foreach (string bloodType in bloodTypes)
            {
                Blood bloodPositive = new Blood()
                {
                    BloodType = Enum.Parse<BloodType>(bloodType),
                    RhFactor = Enum.Parse<RhFactor>("Positive"),
                };

                bloods.Add(bloodPositive);

                Blood bloodNegative = new Blood()
                {
                    BloodType = Enum.Parse<BloodType>(bloodType),
                    RhFactor = Enum.Parse<RhFactor>("Negative"),
                };

                bloods.Add(bloodNegative);
            }

            await dbContext.AddRangeAsync(bloods);
        }
    }
}
