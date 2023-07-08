using AutoPartsShop.Services.Data.Interfaces;
using AutoPartsShop.Web.ViewModels.Vehicle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.Web.Controllers
{
    [Authorize]
    public class VehicleController : BaseController
    {
        private readonly IVehicleCategoryService categoryService;
        private readonly ISellerService sellerService;
        private readonly IVehicleService vehicleService;
        public VehicleController(IVehicleCategoryService service, ISellerService sellerService, IVehicleService vehicleService)
        {
            this.categoryService = service;
            this.sellerService = sellerService;
            this.vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> Add(Guid companyId)
        {
            VehicleFormModel model = new VehicleFormModel()
            {
                Categories = await categoryService.AllAsync(),
                CompanyId = companyId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Guid id, VehicleFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                formModel.Categories = await categoryService.AllAsync();
                return View(formModel);
            }

            if (await sellerService.IsSeller(CurrentUserId(), id))
            {
                return Unauthorized();
            }

            await vehicleService.Add(formModel);

            return RedirectToAction("Overview", "Company", new { id = id });
        }
    }
}
