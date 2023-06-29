using AutoPartsShop.Data.Models;
using AutoPartsShop.Services.Data.Interfaces;
using AutoPartsShop.Web.Data;
using AutoPartsShop.Web.ViewModels.Company;

namespace AutoPartsShop.Services.Data
{
    public class CompanyService : ICompanyService
    {
        private readonly AutoPartsDbContext data;
        public CompanyService(AutoPartsDbContext context)
        {
                data = context;
        }
        public async Task CreateAsync(CompanyFormModel companyModel)
        {
            Company company = new Company()
            {
                Name = companyModel.Name,
                Address = companyModel.Address,
                
            };

            Seller seller = new Seller()
            {
                UserId = companyModel.CurrentUserId,
                CompanyId = company.Id,
                PhoneNumber = companyModel.PhoneNumber,
                IsOwner = true,
            };
            company.Sellers.Add(seller);

            await data.Companies.AddAsync(company);
            await data.SaveChangesAsync();
        }

        public async Task<Company> Details(Guid companyId)
        {
            return await data.Companies.FindAsync(companyId);
        }
    }
}
