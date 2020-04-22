using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloodDonorship.Services.Data.RequestsService
{
    public interface IRequestsService
    {
        int RequestsCount();

        IEnumerable<T> All<T>(int currentPage, int? count = null);

        IEnumerable<T> AllByUser<T>(string userId, int? count = null);

        IEnumerable<T> AllByUserName<T>(string emausernameil, int? count = null);

        Task<string> AddAsync(string userId, int notifiedUsersCount);

        string GetUserId(string requestId); // Requesrer

        Task Delete(string id);
    }
}
