using AutoPartsShop.Services.Data.Interfaces;
using AutoPartsShop.Web.ViewModels.Vehicle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.Web.Controllers
{
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

            if (!await sellerService.IsSeller(CurrentUserId(), id))
            {
                return Unauthorized();
            }
            formModel.CompanyId = id;
            await vehicleService.AddAsync(formModel);

            return RedirectToAction("Overview", "Company", new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            VehicleFormModel model = await vehicleService.GetDataForEditAsync(id);

            if (model == null!)
            {
                return NotFound();
            }
            if (!await sellerService.IsSeller(CurrentUserId(), model.CompanyId))
            {
                return Unauthorized();
            }

            model.Categories = await categoryService.AllAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, VehicleFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                formModel.Categories = await categoryService.AllAsync();
                return View(formModel);
            }

            await vehicleService.EditSaveChanges(id, formModel);
            var vehicle = await vehicleService.GetDataForEditAsync(id);
            return RedirectToAction("Overview", "Company", new { id = vehicle.CompanyId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            VehicleDeleteViewModel model = await vehicleService.GetDataForDeleteAsync(id);

            if (!await sellerService.IsOwner(CurrentUserId(), model.CompanyId))
            {
                return Unauthorized();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            VehicleDeleteViewModel model = await vehicleService.GetDataForDeleteAsync(id);

            if (!await sellerService.IsOwner(CurrentUserId(), model.CompanyId))
            {
                return Unauthorized();
            }
            await vehicleService.DeleteSaveChangesAsync(id);

            return RedirectToAction("Overview", "Company", new { id = model.CompanyId });
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            VehicleDetailsViewModel model = await vehicleService.VehicleDetailsAsync(id);

            if (!await sellerService.IsSeller(CurrentUserId(), model.CompanyId))
            {
                return Unauthorized();
            }

            return View(model);
        }
    }
}
