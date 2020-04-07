using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BloodDonorship.Data;
using BloodDonorship.Data.Common.Repositories;
using BloodDonorship.Data.Models;
using BloodDonorship.Data.Models.Enums;
using BloodDonorship.Data.Repositories;
using BloodDonorship.Services.Data.BloodsService;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BloodDonorship.Services.Data.Tests
{
    public class BloodsServiceTests
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IRepository<Blood> bloodRepository;
        private readonly IBloodsService bloodsService;

        public BloodsServiceTests()
        {
            DbContextOptionsBuilder<ApplicationDbContext> options =
                new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            this.applicationDbContext = new ApplicationDbContext(options.Options);

            this.bloodRepository = new EfRepository<Blood>(this.applicationDbContext);

            this.bloodsService = new BloodsService.BloodsService(this.bloodRepository);

            foreach (Blood blood in this.GetTestBloods())
            {
                this.bloodRepository.AddAsync(blood);
                this.bloodRepository.SaveChangesAsync();
            }
        }

        public IEnumerable<Blood> GetTestBloods()
        {
            List<Blood> bloods = new List<Blood>();
            string[] bloodGroups = { "A", "B", "AB", "O" };

            foreach (string bloodType in bloodGroups)
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

            return bloods;
        }

        [Fact]
        public void GetBloodTypeReturnRightANegativeTest()
        {
            Blood bloodResult = this.bloodsService.GetBlood("A", "Negative");

            Assert.NotNull(bloodResult);
            Assert.Equal("A", bloodResult.BloodType.ToString());
            Assert.Equal("Negative", bloodResult.RhFactor.ToString());
        }

        [Fact]
        public void GetBloodTypeReturnRightABPositiveTest()
        {
            Blood bloodResult = this.bloodsService.GetBlood("AB", "Positive");

            Assert.NotNull(bloodResult);
            Assert.Equal("AB", bloodResult.BloodType.ToString());
            Assert.Equal("Positive", bloodResult.RhFactor.ToString());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("dd", "ffjk")]
        [InlineData("O", null)]
        [InlineData(null, "Negative")]
        public void GetBloodTypeReturnNullTest(string bloodType, string rhFactor)
        {
            Blood bloodResult = this.bloodsService.GetBlood(bloodType, rhFactor);

            Assert.Null(bloodResult);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void GetBloodTypeReturnRightTest(int bloodId)
        {
            string bloodTypeResult = this.bloodsService.GetBloodType(bloodId);

            string[] bloodTypes = { "A", "AB", "O" };

            Assert.Contains(bloodTypeResult, bloodTypes);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(20)]
        [InlineData(-1)]
        public void GetBloodTypeReturnStringEmptyTest(int bloodId)
        {
            string bloodTypeResult = this.bloodsService.GetBloodType(bloodId);

            Assert.Null(bloodTypeResult);
        }

        [Fact]
        public void GetRhFactorReturnRightTest()
        {
            string rhFactorResult;

            for (int i = 1; i <= 8; i++)
            {
                if (i % 2 != 0)
                {
                    rhFactorResult = this.bloodsService.GetRhFactor(i);

                    Assert.Equal("Positive", rhFactorResult);
                }
                else
                {
                    rhFactorResult = this.bloodsService.GetRhFactor(i);

                    Assert.Equal("Negative", rhFactorResult);
                }
            }
        }

        [Fact]
        public void GetRhFactorReturnNullTest()
        {
            string rhFactorResult;

            for (int i = 10; i <= 15; i++)
            {
                rhFactorResult = this.bloodsService.GetRhFactor(i);

                Assert.Null(rhFactorResult);
            }
        }
    }
}
