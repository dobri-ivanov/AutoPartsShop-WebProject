namespace AutoPartsShop.Web.Controllers
{
    using System.Security.Claims;
    using AutoPartsShop.Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using static Common.NotificationMessagesConstants;

    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class BaseController : Controller
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly RoleManager<ApplicationUser> _roleManager;

        public BaseController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationUser> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Guid CurrentUserId()
        {
            return Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public IActionResult GeneralError()
        {
            this.TempData[WarningMessage] = "Unexpected error occurred! Please try again or contact administrator!";
            return RedirectToAction("Error", "Home");
        }
    }
}
