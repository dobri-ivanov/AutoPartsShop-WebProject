namespace AutoPartsShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    
    using AutoPartsShop.Services.Data.Interfaces;
    using AutoPartsShop.Web.ViewModels.Seller;

    public class SellerController : BaseController
    {
        private readonly ISellerService sellerService;

        public SellerController(ISellerService SellerService)
        {
            sellerService = SellerService;
        }

        [HttpGet]
        public async Task<IActionResult> Add(Guid id)
        {
            if (!await sellerService.IsOwner(CurrentUserId(), id))
            {
                return RedirectToAction("Overview", "Company", new { id = id });
            }

            SellerFormModel model = new SellerFormModel()
            {
                Company = id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Guid id, SellerFormModel model)
        {
            if (!await sellerService.IsOwner(CurrentUserId(), id))
            {
                return RedirectToAction("Overview", "Company", new {id = id});
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Guid userId = await sellerService.IsValidEmployee(model.Email);

            if (userId == Guid.Empty)
            {
                ModelState.AddModelError("Email", "Provided email is invalid or employee with proveded email has already been hired!");
                return View(model);
            }
            model.Company = id;
            model.UserId = userId;

            await sellerService.AddEmployeeAsync(model);

            return RedirectToAction("Overview", "Company", new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            Guid companyId = await sellerService.CompanyIdBySellerId(id);

            if (companyId == Guid.Empty)
            {
                return RedirectToAction("Overview", "Company", new { id = companyId });
            }

            if (!await sellerService.IsOwner(CurrentUserId(), companyId))
            {
                return RedirectToAction("Overview", "Company", new {id = companyId});
            }

            SellerEditFormModel model = await sellerService.EditDataAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, SellerEditFormModel formModel)
        {
            Guid companyId = await sellerService.CompanyIdBySellerId(id);

            if (companyId == Guid.Empty)
            {
                return RedirectToAction("Overview", "Company", new {id = companyId});
            }

            if (!await sellerService.IsOwner(CurrentUserId(), companyId))
            {
                return RedirectToAction("Overview", "Company", new { id = companyId });
            }

            if (!ModelState.IsValid)
            {
                return View(formModel);
            }

            await sellerService.EditAsync(id, formModel);

           
            return RedirectToAction("Overview", "Company", new { id = companyId });
        }

        [HttpGet]
        public async Task<IActionResult> Fire(Guid id)
        {
            Guid companyId;
            try
            {
                companyId = await sellerService.CompanyIdBySellerId(id);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }     

            if (companyId == Guid.Empty)
            {
                return RedirectToAction("Overview", "Company", new { id = companyId });
            }

            if (!await sellerService.IsOwner(CurrentUserId(), companyId))
            {
                return RedirectToAction("Overview", "Company", new { id = companyId });
            }          

            SellerFormModel model = await sellerService.DeleteDataAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Guid id)
        {
            Guid companyId = await sellerService.CompanyIdBySellerId(id);

            if (companyId == Guid.Empty)
            {
                return RedirectToAction("Overview", "Company", new { id = companyId });
            }

            if (!await sellerService.IsOwner(CurrentUserId(), companyId))
            {
                return RedirectToAction("Overview", "Company", new { id = companyId });
            }

            await sellerService.DeleteAsync(id);
            return RedirectToAction("Overview", "Company", new { id = companyId });
        }

    }
}
