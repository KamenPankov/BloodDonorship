using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BloodDonorship.Data;
using BloodDonorship.Data.Common.Repositories;
using BloodDonorship.Data.Models;
using BloodDonorship.Data.Repositories;
using BloodDonorship.Services.Data.DonationsService;
using BloodDonorship.Services.Mapping;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BloodDonorship.Services.Data.Tests
{
    public class DonationsServiceTests
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IDeletableEntityRepository<Donation> donationRepository;
        private readonly IDonationsService donationsService;

        public DonationsServiceTests()
        {
            DbContextOptionsBuilder<ApplicationDbContext> options =
                new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            this.applicationDbContext = new ApplicationDbContext(options.Options);

            this.donationRepository = new EfDeletableEntityRepository<Donation>(this.applicationDbContext);

            this.donationsService = new DonationsService.DonationsService(this.donationRepository);

            foreach (Donation donation in this.GetTestDonations())
            {
                this.donationRepository.AddAsync(donation);
                this.donationRepository.SaveChangesAsync();
            }
        }

        public IEnumerable<Donation> GetTestDonations()
        {
            List<Donation> donations = new List<Donation>();

            for (int i = 0; i < 10; i++)
            {
                Donation donation = new Donation()
                {
                    Request = new Request(),
                    User = new ApplicationUser(),
                };

                donations.Add(donation);
            }

            return donations;
        }

        [Fact]
        public void DonationsAllByRequestReturnRightTest()
        {
            Request request = new Request();

            for (int i = 0; i < 4; i++)
            {
                Donation donation = new Donation()
                {
                    Request = request,
                };

                this.donationRepository.AddAsync(donation);
                this.donationRepository.SaveChangesAsync();
            }

            AutoMapperConfig.RegisterMappings(typeof(DonationTestModel).Assembly);

            IEnumerable<DonationTestModel> donationsByRequest =
                this.donationsService.AllByRequest<DonationTestModel>(request.Id);

            Assert.True(donationsByRequest.Count() == 4);
        }

        [Fact]
        public void DonationsAllByRequestReturnEmptyCollectionTest()
        {
            Request request = new Request();

            AutoMapperConfig.RegisterMappings(typeof(DonationTestModel).Assembly);

            IEnumerable<DonationTestModel> donationsByRequest =
                this.donationsService.AllByRequest<DonationTestModel>(request.Id);

            Assert.True(donationsByRequest.Count() == 0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void DonationsAllByRequestReturnEmptyCollectionWithNullInputTest(string requestId)
        {
            AutoMapperConfig.RegisterMappings(typeof(DonationTestModel).Assembly);

            IEnumerable<DonationTestModel> donationsByRequest =
                this.donationsService.AllByRequest<DonationTestModel>(requestId);

            Assert.True(donationsByRequest.Count() == 0);
        }

        [Fact]
        public void DonationsLastDonationDateReturnRightTest()
        {
            ApplicationUser user = new ApplicationUser();

            Donation donation = new Donation()
                {
                    CreatedOn = new DateTime(2019, 8, 15),
                    User = user,
                };
            this.donationRepository.AddAsync(donation);

            Donation donation1 = new Donation()
            {
                CreatedOn = new DateTime(2020, 1, 15),
                User = user,
            };
            this.donationRepository.AddAsync(donation1);

            Donation donation2 = new Donation()
            {
                CreatedOn = new DateTime(2020, 3, 20),
                User = user,
            };
            this.donationRepository.AddAsync(donation2);

            this.donationRepository.SaveChangesAsync();

            DateTime lastDonationDate =
                this.donationsService.LastDonationDate(user.Id);

            Assert.Equal(new DateTime(2020, 3, 20), lastDonationDate);
        }

        [Fact]
        public void DonationsLastDonationDateReturnDefaultDateTest()
        {
            ApplicationUser user = new ApplicationUser();

            DateTime lastDonationDate =
                this.donationsService.LastDonationDate(user.Id);

            Assert.Equal(default(DateTime), lastDonationDate);
        }

        [Fact]
        public void DonationsDeleteWithRightInputTest()
        {
            Donation donation = new Donation();
            this.donationRepository.AddAsync(donation);
            this.donationRepository.SaveChangesAsync();

            this.donationsService.Delete(donation.Id);

            Assert.Equal(this.GetTestDonations().Count(), this.donationRepository.All().Count());
        }

        [Fact]
        public void DonationsDeleteWithWrongInputTest()
        {
            this.donationsService.Delete(Guid.NewGuid().ToString());

            Assert.Equal(this.GetTestDonations().Count(), this.donationRepository.All().Count());
        }

        [Fact]
        public void DonationsDeleteWithNullInputTest()
        {
            this.donationsService.Delete(string.Empty);

            Assert.Equal(this.GetTestDonations().Count(), this.donationRepository.All().Count());
        }

        public class DonationTestModel : IMapFrom<Donation>
        {
        }
    }
}
