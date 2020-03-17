using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BloodDonorship.Data.Common.Repositories;
using BloodDonorship.Data.Models;
using BloodDonorship.Web.ViewModels.Donations;

namespace BloodDonorship.Services.Data.DonationsService
{
    public class DonationsService : IDonationsService
    {
        private readonly IDeletableEntityRepository<Donation> entityRepository;

        public DonationsService(IDeletableEntityRepository<Donation> entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public async Task AddAsync(CreateDonationViewModel viewModel)
        {
            using (MemoryStream memorySream = new MemoryStream())
            {
                await viewModel.FormFile.CopyToAsync(memorySream);

                Donation donation = new Donation()
                {
                    RequestId = viewModel.RequestId,
                    UserId = viewModel.UserId,
                    ImageData = memorySream.ToArray(),
                };

                await this.entityRepository.AddAsync(donation);
                await this.entityRepository.SaveChangesAsync();
            }
        }

        public DateTime LastDonationDate(string userId)
        {
            return this.entityRepository.All()
                        .Where(d => d.UserId == userId)
                        .Select(d => d.CreatedOn)
                        .OrderByDescending(d => d)
                        .FirstOrDefault();
        }
    }
}
