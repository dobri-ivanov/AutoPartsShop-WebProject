using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoPartsShop.Web.Controllers
{   
    public class BaseController : Controller
    {
        public Guid CurrentUserId()
        {
            return Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
