namespace AutoPartsShop.Web.Controllers
{
    using System.Security.Claims;
    
    using Microsoft.AspNetCore.Mvc;
    
    public class BaseController : Controller
    {
        public Guid CurrentUserId()
        {
            return Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
