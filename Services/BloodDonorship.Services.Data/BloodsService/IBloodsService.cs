using System.Collections.Generic;
using System.Text;
using BloodDonorship.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodDonorship.Services.Data.BloodsService
{
    public interface IBloodsService
    {
        IEnumerable<SelectListItem> BloodTypes();

        IEnumerable<SelectListItem> RhFactors();

        Blood GetBlood(string bloodType, string rhFactor);

        string GetBloodType(int bloodId);

        string GetRhFactor(int bloodId);
    }
}
