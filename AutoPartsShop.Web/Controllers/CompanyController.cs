namespace AutoPartsShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using AutoPartsShop.Web.ViewModels.Company;
    using AutoPartsShop.Services.Data.Interfaces;

    [Authorize]
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
            await companyService.CreateAsync(formModel);

            return RedirectToAction("All", "Part");
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
                return RedirectToAction("Overview", "Company");
            }

            CompanyFormModel formModel = await companyService.EditCompanyAsync(id);

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, CompanyFormModel formModel)
        {
            if (!await sellerService.IsOwner(CurrentUserId(), id))
            {
                return RedirectToAction("Overview", "Company");
            }

            await companyService.EditCompanyAsync(id, formModel);

            return RedirectToAction("Overview", new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await sellerService.IsOwner(CurrentUserId(), id))
            {
                return RedirectToAction("Overview", "Company");
            }

            CompanyDeleteViewModel viewModel = await companyService.DeleteCompanyAsync(id);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id, CompanyDeleteViewModel model)
        {
            if (!await sellerService.IsOwner(CurrentUserId(), id))
            {
                return RedirectToAction("Overview", "Company");
            }

            await companyService.DeleteCompanyFromDatabaseAsync(id);

            return RedirectToAction("All", "Part");
        }
    }
}
