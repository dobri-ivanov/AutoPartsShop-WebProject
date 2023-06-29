namespace AutoPartsShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    
    using AutoPartsShop.Web.ViewModels.Company;
    using AutoPartsShop.Services.Data.Interfaces;
    using System.Security.Claims;
    using AutoPartsShop.Data.Models;

    [Authorize]
    public class CompanyController : Controller
    {
        private readonly ICompanyService service;
        public CompanyController(ICompanyService companyService)
        {
            service = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return View(formModel);
            }

            formModel.CurrentUserId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            await service.CreateAsync(formModel);

            return RedirectToAction("All", "Part");
        }

        [HttpGet]
        public async Task<IActionResult> Overview(Guid id)
        {
            Company company = await service.Details(id);
            CompanyOverviewViewModel viewModel = new CompanyOverviewViewModel()
            {
                Name = company.Name,
            };

            return View(viewModel);
        }
    }
}
