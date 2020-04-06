using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using BloodDonorship.Data.Common.Repositories;
using BloodDonorship.Data.Models;
using BloodDonorship.Services.Mapping;
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
                    ImageTitle = viewModel.FileName,
                    ImageData = memorySream.ToArray(),
                };

                await this.entityRepository.AddAsync(donation);
                await this.entityRepository.SaveChangesAsync();
            }
        }

        public byte[] FileContent(string id)
        {
            return this.entityRepository.All()
                .Where(d => d.Id == id)
                .Select(d => d.ImageData)
                .FirstOrDefault();
        }

        public string FileType(string id)
        {
            string fileName = this.entityRepository.All()
                .Where(d => d.Id == id)
                .Select(d => d.ImageTitle)
                .FirstOrDefault();

            return Path.GetExtension(fileName);
        }

        public IEnumerable<T> AllByRequest<T>(string requestId)
        {
            return this.entityRepository.All()
                .Where(d => d.RequestId == requestId)
                .OrderByDescending(d => d.CreatedOn)
                .To<T>()
                .ToArray();
        }

        public IEnumerable<T> AllByUser<T>(string userId)
        {
            return this.entityRepository.All()
                .Where(d => d.UserId == userId)
                .OrderByDescending(d => d.CreatedOn)
                .To<T>()
                .ToArray();
        }

        public DateTime LastDonationDate(string userId)
        {
            return this.entityRepository.All()
                        .Where(d => d.UserId == userId)
                        .Select(d => d.CreatedOn)
                        .OrderByDescending(d => d)
                        .FirstOrDefault();
        }

        public async Task Delete(string donationId)
        {
            Donation donation = this.entityRepository.All().FirstOrDefault(d => d.Id == donationId);

            if (donation != null)
            {
                this.entityRepository.Delete(donation);
                await this.entityRepository.SaveChangesAsync();
            }
        }
    }
}
