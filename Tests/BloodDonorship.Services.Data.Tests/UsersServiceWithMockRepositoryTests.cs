using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodDonorship.Data.Common.Repositories;
using BloodDonorship.Data.Models;
using BloodDonorship.Data.Models.Enums;
using BloodDonorship.Services.Data.UsersService;
using BloodDonorship.Services.Mapping;
using BloodDonorship.Web.ViewModels.Users;
using Moq;
using Xunit;

namespace BloodDonorship.Services.Data.Tests
{
    public class UsersServiceWithMockRepositoryTests
    {
        private readonly IUsersService usersService;
        private IEnumerable<ApplicationUser> testUsersList;
        private Mock<IDeletableEntityRepository<ApplicationUser>> repositoryMock;
        private ApplicationUser testUser;

        public UsersServiceWithMockRepositoryTests()
        {
            this.testUsersList = this.GetTestData();

            this.repositoryMock = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            this.repositoryMock.Setup(r => r.All())
                .Returns(this.testUsersList.AsQueryable<ApplicationUser>());

            this.usersService = new UsersService.UsersService(this.repositoryMock.Object);
            this.testUser = new ApplicationUser()
            {
                Blood = new Blood()
                {
                    BloodType = BloodType.A,
                    RhFactor = RhFactor.Negative,
                },
                Email = $"test_userANegative@gmail.com",
            };
        }

        public IEnumerable<ApplicationUser> GetTestData()
        {
            string[] bloodTypes = { "A", "B", "AB", "O" };

            List<ApplicationUser> users = new List<ApplicationUser>();

            for (int i = 0; i < bloodTypes.Length; i++)
            {
                ApplicationUser userPositive = new ApplicationUser()
                {
                    Blood = new Blood()
                    {
                        BloodType = Enum.Parse<BloodType>(bloodTypes[i]),
                        RhFactor = RhFactor.Positive,
                    },
                    Email = $"test_user{i}@gmail.com",
                };

                users.Add(userPositive);
            }

            for (int i = 0; i < bloodTypes.Length; i++)
            {
                ApplicationUser userNegative = new ApplicationUser()
                {
                    Blood = new Blood()
                    {
                        BloodType = Enum.Parse<BloodType>(bloodTypes[i]),
                        RhFactor = RhFactor.Negative,
                    },
                    Email = $"test_user{i + bloodTypes.Length}@gmail.com",
                };

                users.Add(userNegative);
            }

            return users.AsEnumerable<ApplicationUser>();
        }

        [Fact]
        public void CompatableBloodTypesReturnsRightBloodListForAPositiveTest()
        {
            IEnumerable<(string, string)> resultBloods = this.usersService.CompatableBloodTypes(BloodType.A, RhFactor.Positive);
            IEnumerable<(string, string)> expectedBloods = new List<(string, string)>
            {
                ("A", "Positive"),
                ("A", "Negative"),
                ("O", "Positive"),
                ("O", "Negative"),
            };

            Assert.True(resultBloods.Count() == 4);
            Assert.Equal(expectedBloods, resultBloods);
        }

        [Fact]
        public void CompatableBloodTypesReturnsRightBloodListForABPositiveTest()
        {
            IEnumerable<(string, string)> resultBloods = this.usersService.CompatableBloodTypes(BloodType.AB, RhFactor.Positive);
            IEnumerable<(string, string)> expectedBloods =
                new List<(string, string)>
                {
                    ("A", "Positive"),
                    ("A", "Negative"),
                    ("B", "Positive"),
                    ("B", "Negative"),
                    ("O", "Positive"),
                    ("O", "Negative"),
                    ("AB", "Positive"),
                    ("AB", "Negative"),
                };

            Assert.True(resultBloods.Count() == 8);
            Assert.Equal(expectedBloods, resultBloods);
        }

        [Fact]
        public void CompatableBloodTypesReturnsRightBloodListForUnspecifiedUnspecifiedTest()
        {
            IEnumerable<(string, string)> resultBloods = this.usersService.CompatableBloodTypes(BloodType.Unspecified, RhFactor.Unspecified);
            IEnumerable<(string, string)> expectedBloods = new List<(string, string)>();

            Assert.True(resultBloods.Count() == 0);
            Assert.Equal(expectedBloods, resultBloods);
        }

        [Fact]
        public void GetEligibleDonorsReturnsRightListForUserWithBloodGroupARhFactorNegativeNoDonationsTest()
        {
            IUsersService usersService = new UsersService.UsersService(this.repositoryMock.Object);

            IEnumerable<EligibleUserViewModel> resultUsersList = usersService.GetEligibleDonors(this.testUser);

            Assert.True(resultUsersList.Count() == 2);
        }

        [Fact]
        public void GetEligibleDonorsReturnsRightListForUserBloodGroupARhFactorNegativeWithDonationsTest()
        {
            this.testUsersList = this.testUsersList.ToArray();

            this.testUsersList.ToArray()[4].Donations.Add(new Donation()
            {
                CreatedOn = new DateTime(2020, 3, 29),
            });

            this.testUsersList.ToArray()[7].Donations.Add(new Donation()
            {
                CreatedOn = new DateTime(2020, 1, 10),
            });

            this.repositoryMock.Setup(r => r.All())
                .Returns(this.testUsersList.AsQueryable<ApplicationUser>());

            IUsersService usersService = new UsersService.UsersService(this.repositoryMock.Object);

            IEnumerable<EligibleUserViewModel> resultUsersList = usersService.GetEligibleDonors(this.testUser);

            Assert.True(resultUsersList.Count() == 1);
        }

        [Fact]
        public void GetEligibleDonorsReturnsRightListForUserBloodGroupBRhFactorPositiveNoDonationsTest()
        {
            this.testUser.Blood.BloodType = BloodType.B;
            this.testUser.Blood.RhFactor = RhFactor.Positive;

            this.testUsersList = this.testUsersList.ToArray();

            this.repositoryMock.Setup(r => r.All())
                .Returns(this.testUsersList.AsQueryable<ApplicationUser>());

            IUsersService usersService = new UsersService.UsersService(this.repositoryMock.Object);

            IEnumerable<EligibleUserViewModel> resultUsersList = usersService.GetEligibleDonors(this.testUser);

            Assert.True(resultUsersList.Count() == 4);
        }

        [Fact]
        public void GetEligibleDonorsReturnsRightListForUserBloodGroupBRhFactorPositiveWithDonationsTest()
        {
            this.testUser.Blood.BloodType = BloodType.B;
            this.testUser.Blood.RhFactor = RhFactor.Positive;

            this.testUsersList = this.testUsersList.ToArray();

            this.testUsersList.ToArray()[1].Donations.Add(new Donation()
            {
                CreatedOn = new DateTime(2020, 3, 29),
            });

            this.testUsersList.ToArray()[7].Donations.Add(new Donation()
            {
                CreatedOn = new DateTime(2020, 1, 30),
            });

            this.repositoryMock.Setup(r => r.All())
                .Returns(this.testUsersList.AsQueryable<ApplicationUser>());

            IUsersService usersService = new UsersService.UsersService(this.repositoryMock.Object);

            IEnumerable<EligibleUserViewModel> resultUsersList = usersService.GetEligibleDonors(this.testUser);

            Assert.True(resultUsersList.Count() == 3);
        }

        [Fact]
        public void GetEligibleDonorsReturnsRightListForUserBloodNullTest()
        {
            this.testUser.Blood = null;

            this.testUsersList = this.testUsersList.ToArray();

            this.testUsersList.ToArray()[1].Donations.Add(new Donation()
            {
                CreatedOn = new DateTime(2020, 3, 29),
            });

            this.testUsersList.ToArray()[7].Donations.Add(new Donation()
            {
                CreatedOn = new DateTime(2020, 1, 30),
            });

            this.repositoryMock.Setup(r => r.All())
                .Returns(this.testUsersList.AsQueryable<ApplicationUser>());

            IUsersService usersService = new UsersService.UsersService(this.repositoryMock.Object);

            IEnumerable<EligibleUserViewModel> resultUsersList = usersService.GetEligibleDonors(this.testUser);

            Assert.True(resultUsersList.Count() == 0);
        }

        [Fact]
        public void GetEligibleDonorsReturnsRightListForUserBloodGroupBRhFactorPositiveWithNullBloodTypesTest()
        {
            this.testUser.Blood.BloodType = BloodType.B;
            this.testUser.Blood.RhFactor = RhFactor.Positive;

            this.testUsersList = this.testUsersList.ToArray();

            this.testUsersList.ToArray()[1].Blood = null;

            this.testUsersList.ToArray()[7].Donations.Add(new Donation()
            {
                CreatedOn = new DateTime(2020, 1, 30),
            });

            this.repositoryMock.Setup(r => r.All())
                .Returns(this.testUsersList.AsQueryable<ApplicationUser>());

            IUsersService usersService = new UsersService.UsersService(this.repositoryMock.Object);

            IEnumerable<EligibleUserViewModel> resultUsersList = usersService.GetEligibleDonors(this.testUser);

            Assert.True(resultUsersList.Count() == 3);
        }

        [Fact]
        public void GetEligibleDonorsReturnsRightListForUserBloodGroupBRhFactorPositiveTestUserInList()
        {
            this.testUser.Blood.BloodType = BloodType.B;
            this.testUser.Blood.RhFactor = RhFactor.Positive;

            this.testUsersList = this.testUsersList.ToArray();

            List<ApplicationUser> applicationUsers = new List<ApplicationUser>(this.testUsersList);
            applicationUsers.Add(this.testUser);

            this.testUsersList = applicationUsers.AsEnumerable<ApplicationUser>();

            this.repositoryMock.Setup(r => r.All())
                .Returns(this.testUsersList.AsQueryable<ApplicationUser>());

            IUsersService usersService = new UsersService.UsersService(this.repositoryMock.Object);

            IEnumerable<EligibleUserViewModel> resultUsersList = usersService.GetEligibleDonors(this.testUser);

            Assert.True(resultUsersList.Count() == 4);
        }
    }
}
