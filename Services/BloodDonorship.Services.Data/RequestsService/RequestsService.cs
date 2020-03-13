using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task Add(string userId)
        {
            await this.requestsRepository.AddAsync(new Request()
            {
                UserId = userId,
            });

            await this.requestsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> All<T>(int? count = null)
        {
            IQueryable<Request> query = this.requestsRepository.All()
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
    }
}
