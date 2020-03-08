namespace BloodDonorship.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using BloodDonorship.Data.Common.Repositories;
    using BloodDonorship.Data.Models;
    using BloodDonorship.Services.Mapping;

    public class SettingsService : ISettingsService
    {
        private readonly IDeletableEntityRepository<Setting> settingsRepository;

        public SettingsService(IDeletableEntityRepository<Setting> settingsRepository)
        {
            this.settingsRepository = settingsRepository;
        }

        public int GetCount()
        {
            return this.settingsRepository.All().Count();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.settingsRepository.All().To<T>().ToList();
        }
    }
}
