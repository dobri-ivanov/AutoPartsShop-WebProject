using AutoPartsShop.Data.Models;
using AutoPartsShop.Web.ViewModels.Company;

namespace AutoPartsShop.Services.Data.Interfaces
{
    public interface ICompanyService
    {
        public Task CreateAsync(CompanyFormModel companyModel);
        public Task<Company> Details(Guid companyId);
    }
}
