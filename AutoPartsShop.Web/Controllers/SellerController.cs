using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.Web.Controllers
{
    public class SellerController : Controller
    {
        public async Task<IActionResult> Apply()
        {
            return View();
        }
    }
}
