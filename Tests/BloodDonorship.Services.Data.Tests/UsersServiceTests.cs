using System;
using System.Collections.Generic;
using System.Linq;

using BloodDonorship.Data.Common.Repositories;
using BloodDonorship.Data.Models;
using BloodDonorship.Data.Models.Enums;
using BloodDonorship.Services.Data.UsersService;
using BloodDonorship.Web.ViewModels.Users;
using Moq;
using Xunit;

namespace BloodDonorship.Services.Data.Tests
{
    public class UsersServiceTests
    {
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
            var repositoryMock = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            repositoryMock.Setup(r => r.All())
                .Returns(this.GetTestData().AsQueryable<ApplicationUser>());

            IUsersService usersService = new UsersService.UsersService(repositoryMock.Object);

            IEnumerable<(string, string)> resultBloods = usersService.CompatableBloodTypes(BloodType.A, RhFactor.Positive);
            IEnumerable<(string, string)> expectedBloods = new List<(string, string)> { ("A", "Positive"), ("A", "Negative"), ("O", "Positive"), ("O", "Negative") };

            Assert.True(resultBloods.Count() == 4);
            Assert.Equal(expectedBloods, resultBloods);
        }

        [Fact]
        public void CompatableBloodTypesReturnsRightBloodListForABPositiveTest()
        {
            var repositoryMock = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            repositoryMock.Setup(r => r.All())
                .Returns(this.GetTestData().AsQueryable<ApplicationUser>());

            IUsersService usersService = new UsersService.UsersService(repositoryMock.Object);

            IEnumerable<(string, string)> resultBloods = usersService.CompatableBloodTypes(BloodType.AB, RhFactor.Positive);
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
            var repositoryMock = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            repositoryMock.Setup(r => r.All())
                .Returns(this.GetTestData().AsQueryable<ApplicationUser>());

            IUsersService usersService = new UsersService.UsersService(repositoryMock.Object);

            IEnumerable<(string, string)> resultBloods = usersService.CompatableBloodTypes(BloodType.Unspecified, RhFactor.Unspecified);
            IEnumerable<(string, string)> expectedBloods = new List<(string, string)>();

            Assert.True(resultBloods.Count() == 0);
            Assert.Equal(expectedBloods, resultBloods);
        }

        [Fact]
        public void GetEligibleDonorsReturnsRightListForUserBloodGroupARhFactorNegativeNoDonations()
        {
            ApplicationUser testUser = new ApplicationUser()
            {
                Blood = new Blood()
                {
                    BloodType = BloodType.A,
                    RhFactor = RhFactor.Negative,
                },
                Email = $"test_userANegative@gmail.com",
            };

            var repositoryMock = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            repositoryMock.Setup(r => r.All())
                .Returns(this.GetTestData().AsQueryable<ApplicationUser>());

            IUsersService usersService = new UsersService.UsersService(repositoryMock.Object);

            IEnumerable<EligibleUserViewModel> resultUsersList = usersService.GetEligibleDonors(testUser);

            Assert.True(resultUsersList.Count() == 2);
        }

        [Fact]
        public void GetEligibleDonorsReturnsRightListForUserBloodGroupARhFactorNegativeWithDonations()
        {
            ApplicationUser testUser = new ApplicationUser()
            {
                Blood = new Blood()
                {
                    BloodType = BloodType.A,
                    RhFactor = RhFactor.Negative,
                },
                Email = $"test_userANegative@gmail.com",
            };

            IEnumerable<ApplicationUser> testData = this.GetTestData().ToArray();

            testData.ToArray()[4].Donations.Add(new Donation()
            {
                CreatedOn = new DateTime(2020, 3, 29),
            });

            testData.ToArray()[7].Donations.Add(new Donation()
            {
                CreatedOn = new DateTime(2020, 1, 10),
            });

            var repositoryMock = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            repositoryMock.Setup(r => r.All())
                .Returns(testData.AsQueryable<ApplicationUser>());

            IUsersService usersService = new UsersService.UsersService(repositoryMock.Object);

            IEnumerable<EligibleUserViewModel> resultUsersList = usersService.GetEligibleDonors(testUser);

            Assert.True(resultUsersList.Count() == 1);
        }

        [Fact]
        public void GetEligibleDonorsReturnsRightListForUserBloodGroupBRhFactorPositiveNoDonations()
        {
            ApplicationUser testUser = new ApplicationUser()
            {
                Blood = new Blood()
                {
                    BloodType = BloodType.B,
                    RhFactor = RhFactor.Positive,
                },
                Email = $"test_userANegative@gmail.com",
            };

            IEnumerable<ApplicationUser> testData = this.GetTestData().ToArray();

            var repositoryMock = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            repositoryMock.Setup(r => r.All())
                .Returns(testData.AsQueryable<ApplicationUser>());

            IUsersService usersService = new UsersService.UsersService(repositoryMock.Object);

            IEnumerable<EligibleUserViewModel> resultUsersList = usersService.GetEligibleDonors(testUser);

            Assert.True(resultUsersList.Count() == 4);
        }

        [Fact]
        public void GetEligibleDonorsReturnsRightListForUserBloodGroupBRhFactorPositiveWithDonations()
        {
            ApplicationUser testUser = new ApplicationUser()
            {
                Blood = new Blood()
                {
                    BloodType = BloodType.B,
                    RhFactor = RhFactor.Positive,
                },
                Email = $"test_userANegative@gmail.com",
            };

            IEnumerable<ApplicationUser> testData = this.GetTestData().ToArray();

            testData.ToArray()[1].Donations.Add(new Donation()
            {
                CreatedOn = new DateTime(2020, 3, 29),
            });

            testData.ToArray()[7].Donations.Add(new Donation()
            {
                CreatedOn = new DateTime(2020, 1, 30),
            });

            var repositoryMock = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            repositoryMock.Setup(r => r.All())
                .Returns(testData.AsQueryable<ApplicationUser>());

            IUsersService usersService = new UsersService.UsersService(repositoryMock.Object);

            IEnumerable<EligibleUserViewModel> resultUsersList = usersService.GetEligibleDonors(testUser);

            Assert.True(resultUsersList.Count() == 3);
        }

        [Fact]
        public void GetEligibleDonorsReturnsRightListForUserBloodNull()
        {
            ApplicationUser testUser = new ApplicationUser()
            {
                Blood = null,
                Email = $"test_userANegative@gmail.com",
            };

            IEnumerable<ApplicationUser> testData = this.GetTestData().ToArray();

            testData.ToArray()[1].Donations.Add(new Donation()
            {
                CreatedOn = new DateTime(2020, 3, 29),
            });

            testData.ToArray()[7].Donations.Add(new Donation()
            {
                CreatedOn = new DateTime(2020, 1, 30),
            });

            var repositoryMock = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            repositoryMock.Setup(r => r.All())
                .Returns(testData.AsQueryable<ApplicationUser>());

            IUsersService usersService = new UsersService.UsersService(repositoryMock.Object);

            IEnumerable<EligibleUserViewModel> resultUsersList = usersService.GetEligibleDonors(testUser);

            Assert.True(resultUsersList.Count() == 0);
        }

        [Fact]
        public void GetEligibleDonorsReturnsRightListForUserBloodGroupBRhFactorPositiveWithNullBloodTypes()
        {
            ApplicationUser testUser = new ApplicationUser()
            {
                Blood = new Blood()
                {
                    BloodType = BloodType.B,
                    RhFactor = RhFactor.Positive,
                },
                Email = $"test_userANegative@gmail.com",
            };

            IEnumerable<ApplicationUser> testData = this.GetTestData().ToArray();

            testData.ToArray()[1].Blood = null;

            testData.ToArray()[7].Donations.Add(new Donation()
            {
                CreatedOn = new DateTime(2020, 1, 30),
            });

            var repositoryMock = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            repositoryMock.Setup(r => r.All())
                .Returns(testData.AsQueryable<ApplicationUser>());

            IUsersService usersService = new UsersService.UsersService(repositoryMock.Object);

            IEnumerable<EligibleUserViewModel> resultUsersList = usersService.GetEligibleDonors(testUser);

            Assert.True(resultUsersList.Count() == 2);
        }

        [Fact]
        public void GetEligibleDonorsReturnsRightListForUserBloodGroupBRhFactorPositiveTestUserInList()
        {
            ApplicationUser testUser = new ApplicationUser()
            {
                Blood = new Blood()
                {
                    BloodType = BloodType.B,
                    RhFactor = RhFactor.Positive,
                },
                Email = $"test_userANegative@gmail.com",
            };

            IEnumerable<ApplicationUser> testData = this.GetTestData().ToList();

            List<ApplicationUser> applicationUsers = new List<ApplicationUser>(testData);
            applicationUsers.Add(testUser);

            testData = applicationUsers.AsEnumerable<ApplicationUser>();

            var repositoryMock = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            repositoryMock.Setup(r => r.All())
                .Returns(testData.AsQueryable<ApplicationUser>());

            IUsersService usersService = new UsersService.UsersService(repositoryMock.Object);

            IEnumerable<EligibleUserViewModel> resultUsersList = usersService.GetEligibleDonors(testUser);

            Assert.True(resultUsersList.Count() == 4);
        }
    }
}
