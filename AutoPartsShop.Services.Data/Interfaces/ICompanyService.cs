using AutoPartsShop.Web.ViewModels.Company;

namespace AutoPartsShop.Services.Data.Interfaces
{
    public interface ICompanyService
    {
        public Task CreateAsync(CompanyFormModel companyModel);
        public Task<CompanyOverviewViewModel> OverviewData(Guid companyId);
        public Task<CompanyFormModel> EditCompanyAsync(Guid companyId);
        public Task EditCompanyAsync(Guid companyId, CompanyFormModel formModel);
        public Task<CompanyDeleteViewModel> DeleteCompanyAsync(Guid companyId);
        public Task DeleteCompanyFromDatabaseAsync(Guid companyId);
    }
}
