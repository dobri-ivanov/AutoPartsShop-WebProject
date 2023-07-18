namespace AutoPartsShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using AutoPartsShop.Web.ViewModels.Company;
    using AutoPartsShop.Services.Data.Interfaces;

    public class CompanyController : BaseController
    {
        private readonly ICompanyService companyService;
        private readonly ISellerService sellerService;
        public CompanyController(ICompanyService companyService, ISellerService sellerService)
        {
            this.companyService = companyService;
            this.sellerService = sellerService;

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (await sellerService.IsSeller(CurrentUserId()))
            {
                return RedirectToAction("All", "Part");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return View(formModel);
            }

            
            formModel.CurrentUserId = CurrentUserId();
            formModel.Id = Guid.NewGuid();
            await companyService.CreateAsync(formModel);

            return RedirectToAction("Overview", new { id = formModel.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Overview(Guid id)
        {
            CompanyOverviewViewModel viewModel = await companyService.OverviewData(id);
            if (viewModel == null)
            {
                return RedirectToAction("All", "Part");
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (!await sellerService.IsOwner(CurrentUserId(), id))
            {
                return RedirectToAction("Overview", new { id = id });
            }

            CompanyFormModel formModel = await companyService.EditCompanyAsync(id);

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, CompanyFormModel formModel)
        {
            if (!await sellerService.IsOwner(CurrentUserId(), id))
            {
                return RedirectToAction("Overview", new { id = id });
            }

            await companyService.EditCompanyAsync(id, formModel);

            return RedirectToAction("Overview", new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await sellerService.IsOwner(CurrentUserId(), id))
            {
                return RedirectToAction("Overview", new { id = id });
            }

            CompanyDeleteViewModel viewModel = await companyService.DeleteCompanyAsync(id);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id, CompanyDeleteViewModel model)
        {
            if (!await sellerService.IsOwner(CurrentUserId(), id))
            {
                return RedirectToAction("Overview", new { id = id });
            }

            await companyService.DeleteCompanyFromDatabaseAsync(id);

            return RedirectToAction("All", "Part");
        }
    }
}
