using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BloodDonorship.Common;
using BloodDonorship.Data.Common.Repositories;
using BloodDonorship.Data.Models;
using BloodDonorship.Services.Mapping;

namespace BloodDonorship.Services.Data.RequestsService
{
    public class RequestsService : IRequestsService
    {
        private readonly IDeletableEntityRepository<Request> requestsRepository;

        public RequestsService(IDeletableEntityRepository<Request> requestsRepository)
        {
            this.requestsRepository = requestsRepository;
        }

        public async Task<string> Add(string userId, int notifiedUsersCount)
        {
            Request request = new Request()
            {
                UserId = userId,
                NotifiedUsersCount = notifiedUsersCount,
            };

            await this.requestsRepository.AddAsync(request);

            await this.requestsRepository.SaveChangesAsync();

            return request.Id;
        }

        public IEnumerable<T> All<T>(int currentPage, int? count = null)
        {
            if (currentPage < 1)
            {
                currentPage = 1;
            }

            IQueryable<Request> query = this.requestsRepository.All()
                .OrderByDescending(r => r.CreatedOn);

            if (count.HasValue)
            {
                query = query.Skip((currentPage - 1) * count.Value).Take(count.Value);
            }

            return query.To<T>().ToArray();
        }

        public IEnumerable<T> AllByEmail<T>(string email, int? count = null)
        {
            IQueryable<Request> query = this.requestsRepository.All()
                .Where(r => r.User.Email.Contains(email))
                .OrderByDescending(r => r.CreatedOn);

            if (count.HasValue)
            {
                query.Take(count.Value);
            }

            return query.To<T>().ToArray();
        }

        public IEnumerable<T> AllByUser<T>(string userId, int? count = null)
        {
            IQueryable<Request> query = this.requestsRepository.All()
                 .Where(r => r.UserId == userId)
                 .OrderByDescending(r => r.CreatedOn);

            if (count.HasValue)
            {
                query.Take(count.Value);
            }

            return query.To<T>().ToArray();
        }

        public async Task Delete(string id)
        {
            Request request = this.requestsRepository.All()
                .FirstOrDefault(r => r.Id == id);

            if (request != null)
            {
                this.requestsRepository.Delete(request);
                await this.requestsRepository.SaveChangesAsync();
            }
        }

        public string GetUserId(string requestId)
        {
            return this.requestsRepository.All()
                .Where(r => r.Id == requestId)
                .Select(r => r.UserId)
                .FirstOrDefault();
        }

        public int RequestsCount()
        {
            return this.requestsRepository.All().Count();
        }
    }
}
