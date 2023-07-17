namespace AutoPartsShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using AutoPartsShop.Services.Data.Interfaces;
    using AutoPartsShop.Web.ViewModels.Part;

    [Authorize]
    public class PartController : BaseController
    {
        private readonly IPartService partService;
        private readonly IVehicleService vehicleService;
        private readonly ISellerService sellerService;

        public PartController(IPartService service, IVehicleService vehicleService, ISellerService sellerService)
        {
            this.partService = service;
            this.vehicleService = vehicleService;
            this.sellerService = sellerService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return View(await partService.All());
        }

        [HttpGet]
        public async Task<IActionResult> Add(Guid id)
        {
            if (!await sellerService.IsSeller(CurrentUserId(), id))
            {
                return Unauthorized();
            }

            PartFormModel model = new PartFormModel()
            {
                Vehicles = await vehicleService.SelectVehicles(id),
                CompanyId = id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PartFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Vehicles = await vehicleService.SelectVehicles(model.CompanyId);
                return View(model);
            }

            if (!await sellerService.IsSeller(CurrentUserId(), model.CompanyId))
            {
                return Unauthorized();
            }

            await partService.AddSaveChangesAsync(model);

            return RedirectToAction("Overview", "Company", new { id = model.CompanyId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            PartDeleteViewModel? model = await partService.DeleteDataAsync(id);

            if (model == null!)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            Guid vehicleId = await partService.DeleteAsync(id);

            if (vehicleId == Guid.Empty)
            {
                return NotFound();
            }

            return RedirectToAction("Details", "Vehicle", new { id = vehicleId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            PartFormModel? model = await partService.EditDataAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            model.Vehicles = await vehicleService.SelectVehicles(model.CompanyId);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, PartFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Guid vehicleId = await partService.EditSaveChangesAsync(id, model);

            if (vehicleId == Guid.Empty)
            {
                return NotFound();
            }

            return RedirectToAction("Details", "Vehicle", new { id = vehicleId });
        }

    }
}
