using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BloodDonorship.Data;
using BloodDonorship.Data.Common.Repositories;
using BloodDonorship.Data.Models;
using BloodDonorship.Data.Models.Enums;
using BloodDonorship.Data.Repositories;
using BloodDonorship.Services.Data.UsersService;
using BloodDonorship.Services.Mapping;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BloodDonorship.Services.Data.Tests
{
    public class UsersServiceWithInMemoryDbTests
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IUsersService usersService;

        public UsersServiceWithInMemoryDbTests()
        {
            DbContextOptionsBuilder<ApplicationDbContext> options =
                new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            this.applicationDbContext = new ApplicationDbContext(options.Options);

            this.usersRepository = new EfDeletableEntityRepository<ApplicationUser>(this.applicationDbContext);

            this.usersService = new UsersService.UsersService(this.usersRepository);

            foreach (ApplicationUser user in this.GetTestUsers())
            {
                this.usersRepository.AddAsync(user);
                this.usersRepository.SaveChangesAsync();
            }
        }

        public IEnumerable<ApplicationUser> GetTestUsers()
        {
            string[] bloodTypes = { "A", "B", "AB", "O" };

            List<ApplicationUser> users = new List<ApplicationUser>();
            DateTime donationDate = DateTime.UtcNow;

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
                    UserName = $"User{i}",
                    Donations = new List<Donation>(),
                    Requests = new List<Request>(),
                };

                userPositive.Donations.Add(new Donation()
                {
                    CreatedOn = donationDate.AddDays((-1) * (i + 1)),
                });

                userPositive.Requests.Add(new Request()
                {
                    CreatedOn = donationDate.AddDays((-1) * (i + 1)),
                });

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
                    UserName = $"User{i + bloodTypes.Length}",
                    Donations = new List<Donation>(),
                    Requests = new List<Request>(),
                };

                userNegative.Donations.Add(new Donation()
                {
                    CreatedOn = donationDate.AddDays((-1) * (i + bloodTypes.Length + 1)),
                });

                userNegative.Requests.Add(new Request()
                {
                    CreatedOn = donationDate.AddDays((-1) * (i + bloodTypes.Length + 1)),
                });

                users.Add(userNegative);
            }

            return users;
        }

        [Fact]
        public async Task DeleteUserRightInputTest()
        {
            ApplicationUser testUser = new ApplicationUser();

            await this.usersRepository.AddAsync(testUser);
            await this.usersRepository.SaveChangesAsync();

            int usersCountBeforeDeletion = this.usersRepository.All().Count();

            await this.usersService.DeleteUser(testUser.Id);

            int usersCountAfterDeletion = this.usersRepository.All().Count();

            Assert.Equal(1, usersCountBeforeDeletion - usersCountAfterDeletion);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("19ead944-e428-4ede-9aab-154c782d761e")]
        public async Task DeleteUserWrongInputTest(string userId)
        {
            int usersCountBeforeDeletion = this.usersRepository.All().Count();

            await this.usersService.DeleteUser(userId);

            int usersCountAfterDeletion = this.usersRepository.All().Count();

            Assert.Equal(usersCountBeforeDeletion, usersCountAfterDeletion);
        }

        [Fact]
        public async Task UndeleteUserRightInputTest()
        {
            ApplicationUser testUser = new ApplicationUser();

            await this.usersRepository.AddAsync(testUser);
            await this.usersRepository.SaveChangesAsync();

            int usersCountBeforeAction = this.usersRepository.All().Count();

            await this.usersService.DeleteUser(testUser.Id);
            await this.usersService.UndeleteUser(testUser.Id);

            int usersCountAfterAction = this.usersRepository.All().Count();

            Assert.Equal(usersCountBeforeAction, usersCountAfterAction);
            Assert.False(testUser.IsDeleted);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("19ead944-e428-4ede-9aab-154c782d761e")]
        public async Task UndeleteUserWrongInputTest(string userId)
        {
            int usersCountBeforeAction = this.usersRepository.All().Count();

            await this.usersService.UndeleteUser(userId);

            int usersCountAfterAction = this.usersRepository.All().Count();

            Assert.Equal(usersCountBeforeAction, usersCountAfterAction);
        }

        [Fact]
        public async Task MostDonatedBloodTypeClearFavouriteTest()
        {
            ApplicationUser testUser = new ApplicationUser()
            {
                Blood = new Blood()
                {
                    BloodType = BloodType.A,
                    RhFactor = RhFactor.Negative,
                },
            };

            List<Donation> testUserDonations = new List<Donation>();
            testUserDonations.Add(new Donation());
            testUserDonations.Add(new Donation());

            testUser.Donations = testUserDonations;

            await this.usersRepository.AddAsync(testUser);
            await this.usersRepository.SaveChangesAsync();

            string result = this.usersService.MostDonatedBloodType();

            Assert.Equal("A Negative", result);
        }

        [Fact]
        public void MostDonatedBloodTypeEqualDonationsCountTest()
        {
            string result = this.usersService.MostDonatedBloodType();

            Assert.Equal("A Positive", result);
        }

        [Fact]
        public async Task MostDonatedBloodTypeZeroDonationsCountTest()
        {
            foreach (ApplicationUser user in this.GetTestUsers())
            {
                user.Donations.Clear();
            }

            await this.usersRepository.SaveChangesAsync();

            string result = this.usersService.MostDonatedBloodType();

            Assert.Equal("A Positive", result);
        }

        [Fact]
        public async Task MostWantedBloodTypeClearFavouriteTest()
        {
            ApplicationUser testUser = new ApplicationUser()
            {
                Blood = new Blood()
                {
                    BloodType = BloodType.O,
                    RhFactor = RhFactor.Negative,
                },
            };

            List<Request> testUserRequests = new List<Request>();
            testUserRequests.Add(new Request());
            testUserRequests.Add(new Request());

            testUser.Requests = testUserRequests;

            await this.usersRepository.AddAsync(testUser);
            await this.usersRepository.SaveChangesAsync();

            string result = this.usersService.MostWantedBloodType();

            Assert.Equal("O Negative", result);
        }

        [Fact]
        public void MostWantedBloodTypeEqualRequestsCountTest()
        {
            string result = this.usersService.MostWantedBloodType();

            Assert.Equal("A Positive", result);
        }

        [Fact]
        public async Task MostWantedBloodTypeZeroRequestsCountTest()
        {
            foreach (ApplicationUser user in this.GetTestUsers())
            {
                user.Requests.Clear();
            }

            await this.usersRepository.SaveChangesAsync();

            string result = this.usersService.MostWantedBloodType();

            Assert.Equal("A Positive", result);
        }

        [Fact]
        public void AvailableDonorsZeroCountTest()
        {
            int result = this.usersService.AvailableDonors();

            Assert.Equal(0, result);
        }

        [Fact]
        public async Task AvailableDonorsClearFavouritesWithoutDonationsTest()
        {
            for (int i = 0; i < 2; i++)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Blood = new Blood()
                    {
                        BloodType = BloodType.O,
                        RhFactor = RhFactor.Negative,
                    },
                    Donations = new List<Donation>(),
                };

                await this.usersRepository.AddAsync(user);
            }

            await this.usersRepository.SaveChangesAsync();

            int result = this.usersService.AvailableDonors();

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task AvailableDonorsClearFavouritesWithOldEnoughDonationsTest()
        {
            for (int i = 0; i < 3; i++)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Blood = new Blood()
                    {
                        BloodType = BloodType.AB,
                        RhFactor = RhFactor.Negative,
                    },
                    Donations = new List<Donation>(),
                };

                user.Donations.Add(new Donation()
                {
                    CreatedOn = DateTime.UtcNow.AddDays((-1) * (60 + i)),
                });

                await this.usersRepository.AddAsync(user);
            }

            await this.usersRepository.SaveChangesAsync();

            int result = this.usersService.AvailableDonors();

            Assert.Equal(3, result);
        }

        [Fact]
        public async Task AvailableDonorsAllUsersDeletedTest()
        {
            List<ApplicationUser> users = this.usersRepository.All().ToList();

            foreach (ApplicationUser user in users)
            {
                this.usersRepository.Delete(user);
            }

            await this.usersRepository.SaveChangesAsync();

            int result = this.usersService.AvailableDonors();

            Assert.Equal(0, result);
        }

        [Fact]
        public async Task GetAllUsersDeletedTest()
        {
            for (int i = 0; i < 3; i++)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = $"Usertest{i}",
                    IsDeleted = true,
                };

                await this.usersRepository.AddAsync(user);
            }

            await this.usersRepository.SaveChangesAsync();

            AutoMapperConfig.RegisterMappings(typeof(UserTestModel).Assembly);

            IEnumerable<UserTestModel> deletedUsers = this.usersService.GetAllUsersDeleted<UserTestModel>();

            Assert.Equal(3, deletedUsers.Count());
        }

        [Fact]
        public async Task GetAllUsersDeletedWithAnonymousUserTest()
        {
            for (int i = 0; i < 3; i++)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = $"Usertest{i}",
                    IsDeleted = true,
                };

                await this.usersRepository.AddAsync(user);
            }

            await this.usersRepository.SaveChangesAsync();

            ApplicationUser userAnonymous = new ApplicationUser();
            await this.usersRepository.AddAsync(userAnonymous);
            await this.usersRepository.SaveChangesAsync();

            AutoMapperConfig.RegisterMappings(typeof(UserTestModel).Assembly);

            IEnumerable<UserTestModel> deletedUsers = this.usersService.GetAllUsersDeleted<UserTestModel>();

            Assert.Equal(3, deletedUsers.Count());
        }

        [Fact]
        public async Task GetAllUsersWithDeletedAndAnonymousTest()
        {
            for (int i = 0; i < 3; i++)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = $"Usertest{i}",
                    IsDeleted = true,
                };

                await this.usersRepository.AddAsync(user);
            }

            await this.usersRepository.SaveChangesAsync();

            ApplicationUser userAnonymous = new ApplicationUser();
            await this.usersRepository.AddAsync(userAnonymous);
            await this.usersRepository.SaveChangesAsync();

            AutoMapperConfig.RegisterMappings(typeof(UserTestModel).Assembly);

            IEnumerable<UserTestModel> users = this.usersService.GetAllUsers<UserTestModel>();

            Assert.Equal(this.GetTestUsers().Count(), users.Count());
        }

        [Fact]
        public async Task GetAllUsersWithZeroCollectionTest()
        {
            List<ApplicationUser> users = this.usersRepository.All().ToList();

            foreach (ApplicationUser user in users)
            {
                this.usersRepository.Delete(user);
            }

            await this.usersRepository.SaveChangesAsync();

            AutoMapperConfig.RegisterMappings(typeof(UserTestModel).Assembly);

            IEnumerable<UserTestModel> usersAll = this.usersService.GetAllUsers<UserTestModel>();

            Assert.Empty(usersAll);
        }

        [Fact]
        public async Task GetUserIdByEmailTest()
        {
            ApplicationUser testUser = new ApplicationUser()
            {
                Email = "testuser.email@gmail.com",
            };

            string testUserId = testUser.Id;

            await this.usersRepository.AddAsync(testUser);
            await this.usersRepository.SaveChangesAsync();

            string resultUserId = this.usersService.GetUserIdByEmail("testuser.email@gmail.com");

            Assert.Equal(testUserId, resultUserId);
        }

        [Fact]
        public void GetUserIdByEmailReturnsNullTest()
        {
            string resultUserId = this.usersService.GetUserIdByEmail("testuser.email@gmail.com");

            Assert.True(string.IsNullOrEmpty(resultUserId));
        }

        [Fact]
        public async Task AddAnonymousUserTest()
        {
            ApplicationUser anonymousUser = new ApplicationUser()
            {
                Email = "anonymous@gmail.com",
            };

            string anonymousUserId = await this.usersService.AddAnonymousUser("anonymous@gmail.com");

            string getAnonymousUserId = this.usersService.GetUserIdByEmail("anonymous@gmail.com");

            Assert.Equal(anonymousUserId, getAnonymousUserId);
        }

        public class UserTestModel : IMapFrom<ApplicationUser>
        {
        }
    }
}
