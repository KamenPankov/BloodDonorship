namespace BloodDonorship.Web.Areas.Administration.Controllers
{
    using BloodDonorship.Common;
    using BloodDonorship.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
