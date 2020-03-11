using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BloodDonorship.Data.Common.Repositories;
using BloodDonorship.Data.Models;
using BloodDonorship.Services.Data.BloodsService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodDonorship.Web.Areas.Identity.Pages.Account.Manage
{
    public class BloodModel : PageModel
    {
        private readonly IBloodsService bloodsService;
        private readonly UserManager<ApplicationUser> userManager;

        public BloodModel(IBloodsService bloodsService, UserManager<ApplicationUser> userManager)
        {
            this.bloodsService = bloodsService;
            this.userManager = userManager;
        }

        [BindProperty]
        [Display(Name = "Blood Type")]
        public string BloodType { get; set; }

        public IEnumerable<SelectListItem> BloodTypes { get; set; }

        [BindProperty]
        [Display(Name = "Rh Factor")]
        public string RhFactor { get; set; }

        public IEnumerable<SelectListItem> RhFactors { get; set; }

        public async Task LoadAsync(ApplicationUser user)
        {
            if (user?.BloodId > 0)
            {
                this.BloodType = this.bloodsService.GetBloodType(user.BloodId.Value);
                this.RhFactor = this.bloodsService.GetRhFactor(user.BloodId.Value);
            }
            else
            {
                this.BloodType = "Unspecified";
                this.RhFactor = "Unspecified";
            }

            this.BloodTypes = this.bloodsService.BloodTypes();
            this.RhFactors = this.bloodsService.RhFactors();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ApplicationUser user = await this.userManager.GetUserAsync(this.User);

            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");                
            }

            await this.LoadAsync(user);

            return this.Page();
        }

        public async Task<IActionResult> OnPost()
        {
            ApplicationUser user = await this.userManager.GetUserAsync(this.User);

            if (this.BloodType != "Unspecified" && this.RhFactor != "Unspecified")
            {
                user.Blood = this.bloodsService.GetBlood(this.BloodType, this.RhFactor);

                await this.userManager.UpdateAsync(user);

                await this.LoadAsync(user);
            }
            else
            {
                this.ModelState.AddModelError("Error", "Select blood type and rh factor.");

                await this.LoadAsync(user);
            }

            return this.Page();
        }
    }
}
