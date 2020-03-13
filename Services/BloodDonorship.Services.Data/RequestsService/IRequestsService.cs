using BloodDonorship.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorship.Services.Data.RequestsService
{
    public interface IRequestsService
    {
        IEnumerable<T> All<T>(int? count = null);

        IEnumerable<T> AllByUser<T>(string userId, int? count = null);

        Task Add(string userId);
    }
}
