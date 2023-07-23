namespace AutoPartsShop.Web.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static Common.NotificationMessagesConstants;

    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class BaseController : Controller
    {
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
