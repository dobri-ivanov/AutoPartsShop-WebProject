namespace AutoPartsShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    using AutoPartsShop.Services.Data.Interfaces;
    
    [Authorize]
    public class PartController : Controller
    {
        private readonly IPartService partService;

        public PartController(IPartService service)
        {
            partService = service;
        }
        public async Task<IActionResult> All()
        {            
            return View(await partService.All());
        }
    }
}
