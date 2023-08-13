using AutoPartsShop.Services.Data.Interfaces;
using AutoPartsShop.Web.ViewModels.Order;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.Web.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IPartService partService;

        public OrderController(IPartService service)
        {
                partService = service;
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid id)
        {
            var part = await partService.InfoAsync(id);

            if (part == null)
            {
                return NotFound();
            }

            OrderViewModel model = new OrderViewModel()
            {
                Part = part
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guid id, OrderViewModel model)
        {
            var part = await partService.InfoAsync(id);

            if (part == null)
            {
                return NotFound();
            }

            OrderViewModel model = new OrderViewModel()
            {
                Part = part
            };

            return View(model);
        }
    }
}
