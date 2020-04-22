using System;
using System.Collections.Generic;
using System.Linq;

using BloodDonorship.Common;
using BloodDonorship.Data;
using BloodDonorship.Data.Common.Repositories;
using BloodDonorship.Data.Models;
using BloodDonorship.Data.Repositories;
using BloodDonorship.Services.Data.RequestsService;
using BloodDonorship.Services.Mapping;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BloodDonorship.Services.Data.Tests
{
    public class RequestsServiceTests
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IDeletableEntityRepository<Request> requestRepository;
        private readonly IRequestsService requestsService;

        public RequestsServiceTests()
        {
            DbContextOptionsBuilder<ApplicationDbContext> options =
                new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            this.applicationDbContext = new ApplicationDbContext(options.Options);

            this.requestRepository = new EfDeletableEntityRepository<Request>(this.applicationDbContext);

            this.requestsService = new RequestsService.RequestsService(this.requestRepository);

            foreach (Request request in this.GetTestRequests())
            {
                this.requestRepository.AddAsync(request);
                this.requestRepository.SaveChangesAsync();
            }
        }

        private string RequestEightId { get; set; }

        private string UserRequestEightId { get; set; }

        public IEnumerable<Request> GetTestRequests()
        {
            List<Request> requests = new List<Request>();
            string[] userNameSuffix = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n" };

            for (int i = 0; i < 10; i++)
            {
                Request request = new Request()
                {
                    User = new ApplicationUser()
                    {
                        Email = $"test_email{i}@gmail.com",
                        UserName = $"User{userNameSuffix[i]}",
                    },
                };

                requests.Add(request);
            }

            this.RequestEightId = requests[8].Id;
            this.UserRequestEightId = requests[8].User.Id;

            return requests;
        }

        [Fact]
        public void RequestsCountTest()
        {
            int requestsCount = this.requestsService.RequestsCount();

            Assert.Equal(10, requestsCount);
        }

        [Fact]
        public void RequestsAllTest()
        {
            AutoMapperConfig.RegisterMappings(typeof(RequestTestModel).Assembly);

            IEnumerable<RequestTestModel> requestsAll = this.requestsService.All<RequestTestModel>(1);

            Assert.Equal(10, requestsAll.Count());
        }

        [Theory]
        [InlineData("Usera")]
        [InlineData("Userc")]
        [InlineData("Userg")]
        public void RequestsAllByUserNameReturnRightFullUserNameTest(string username)
        {
            AutoMapperConfig.RegisterMappings(typeof(RequestTestModel).Assembly);

            IEnumerable<RequestTestModel> requestsAllByUserName = this.requestsService.AllByUserName<RequestTestModel>(username);

            Assert.Single(requestsAllByUserName);
        }

        [Theory]
        [InlineData("Us")]
        [InlineData("uSeR")]
        [InlineData("eR")]
        [InlineData("sEr")]
        public void RequestsAllByUserNameReturnRightPartOfUserNameTest(string username)
        {
            AutoMapperConfig.RegisterMappings(typeof(RequestTestModel).Assembly);

            IEnumerable<RequestTestModel> requestsAllByUserName = this.requestsService.AllByUserName<RequestTestModel>(username);

            Assert.Equal(10, requestsAllByUserName.Count());
        }

        [Theory]
        [InlineData("someUser")]
        [InlineData("someone")]
        public void RequestsAllByUserNameReturnEmptyCollectionTest(string username)
        {
            AutoMapperConfig.RegisterMappings(typeof(RequestTestModel).Assembly);

            IEnumerable<RequestTestModel> requestsAllByUserName = this.requestsService.AllByUserName<RequestTestModel>(username);

            Assert.True(!requestsAllByUserName.Any());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void RequestsAllByUserNameReturnAllEmptyInputTest(string username)
        {
            AutoMapperConfig.RegisterMappings(typeof(RequestTestModel).Assembly);

            IEnumerable<RequestTestModel> requestsAllByUserName = this.requestsService.AllByUserName<RequestTestModel>(username);

            Assert.Equal(GlobalConstants.RequestsPerPage, requestsAllByUserName.Count());
        }

        [Fact]
        public void RequestsAllByUserReturnRightTest()
        {
            // new user
            ApplicationUser user = new ApplicationUser();

            // new dbcontext
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase<ApplicationDbContext>(Guid.NewGuid().ToString());
            ApplicationDbContext dbContext = new ApplicationDbContext(options.Options);

            // new repository
            EfDeletableEntityRepository<Request> reqRepository = new EfDeletableEntityRepository<Request>(dbContext);

            // new service
            IRequestsService reqService = new RequestsService.RequestsService(reqRepository);

            // add to db
            for (int i = 0; i < 3; i++)
            {
                Request request = new Request()
                {
                    UserId = user.Id,
                    User = user,
                };

                reqRepository.AddAsync(request);
                reqRepository.SaveChangesAsync();
            }

            for (int i = 0; i < 10; i++)
            {
                Request request = new Request()
                {
                    User = new ApplicationUser(),
                };

                reqRepository.AddAsync(request);
                reqRepository.SaveChangesAsync();
            }

            AutoMapperConfig.RegisterMappings(typeof(RequestTestModel).Assembly);

            IEnumerable<RequestTestModel> requestsAllByUser = reqService.AllByUser<RequestTestModel>(user.Id);

            Assert.True(requestsAllByUser.Count() == 3);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("19ead944-e428-4ede-9aab-154c782d761e")]
        public void RequestsAllByUserReturnEmptyCollectionTest(string userId)
        {
            AutoMapperConfig.RegisterMappings(typeof(RequestTestModel).Assembly);

            IEnumerable<RequestTestModel> requestsAllByUser = this.requestsService.AllByUser<RequestTestModel>(userId);

            Assert.True(requestsAllByUser.Count() == 0);
        }

        [Fact]
        public void RequestsGetUserIdReturnRightTest()
        {
            AutoMapperConfig.RegisterMappings(typeof(RequestTestModel).Assembly);

            string userRequestEightId = this.requestsService.GetUserId(this.RequestEightId);

            Assert.Equal(this.UserRequestEightId, userRequestEightId);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("19ead944-e428-4ede-9aab-154c782d761e")]
        public void RequestsGetUserIdReturnEmptyStringTest(string userId)
        {
            AutoMapperConfig.RegisterMappings(typeof(RequestTestModel).Assembly);

            string userRequestId = this.requestsService.GetUserId(userId);

            Assert.True(string.IsNullOrEmpty(userRequestId));
        }

        public class RequestTestModel : IMapFrom<Request>
        {
        }
    }
}
