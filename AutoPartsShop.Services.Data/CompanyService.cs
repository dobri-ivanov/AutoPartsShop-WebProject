namespace AutoPartsShop.Services.Data
{
    using AutoPartsShop.Data.Models;
    using Interfaces;
    using AutoPartsShop.Web.Data;
    using AutoPartsShop.Web.ViewModels.Company;
    using Microsoft.EntityFrameworkCore;
    using AutoPartsShop.Web.ViewModels.Seller;
    using System.Security.Claims;

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
                FirstName = companyModel.FirstName,
                LastName = companyModel.LastName,
                UserId = companyModel.CurrentUserId,
                CompanyId = company.Id,
                PhoneNumber = companyModel.PhoneNumber,
                IsOwner = true,
            };
            company.Sellers.Add(seller);

            await data.Companies.AddAsync(company);
            await data.SaveChangesAsync();
        }

        public async Task<CompanyDeleteViewModel> DeleteCompanyAsync(Guid companyId)
        {
            if (companyId == Guid.Empty)
            {
                return null;
            }


            Company company = await data.Companies
                .Include(c => c.Sellers)
                .FirstAsync(c => c.Id == companyId);

            CompanyDeleteViewModel viewModel = new CompanyDeleteViewModel()
            {
                Id = companyId,
                Name = company.Name,
                Address = company.Address,
                EmployeeCount = company.Sellers.Count()
            };

            return viewModel;
        }

        public async Task DeleteCompanyFromDatabaseAsync(Guid companyId)
        {
            Company company = await data.Companies.FirstAsync(c => c.Id == companyId);

            data.Companies.Remove(company);
            await data.SaveChangesAsync();
        }

        public async Task<CompanyFormModel> EditCompanyAsync(Guid companyId)
        {
            Company company = await data.Companies
                .Include(c => c.Sellers)
                .FirstAsync(c => c.Id == companyId);
            CompanyFormModel companyFormModel = new CompanyFormModel();
            if (company != null)
            {
                companyFormModel = new CompanyFormModel()
                {
                    Id = companyId,
                    Name = company.Name,
                    Address = company.Address,
                };

                Seller owner = await data.Sellers.FirstAsync(s => s.CompanyId == companyId && s.IsOwner);
                if (owner != null)
                {
                    companyFormModel.FirstName = owner.FirstName;
                    companyFormModel.LastName = owner.LastName;
                    companyFormModel.PhoneNumber = owner.PhoneNumber;
                }
            }

            return companyFormModel;
        }

        public async Task EditCompanyAsync(Guid companyId, CompanyFormModel formModel)
        {
            Company company = await data.Companies.FirstAsync(c => c.Id == companyId);

            if (company != null)
            {
                company.Name = formModel.Name;
                company.Address = formModel.Address;
            }

            Seller owner = await data.Sellers.FirstAsync(c => c.CompanyId == companyId && c.IsOwner);

            if (owner != null)
            {
                owner.FirstName = formModel.FirstName;
                owner.LastName = formModel.LastName;
                owner.PhoneNumber = formModel.PhoneNumber;
            }

            await data.SaveChangesAsync();
        }

        public async Task<CompanyOverviewViewModel> OverviewData(Guid companyId)
        {
            if (companyId == Guid.Empty)
            {
                return null;
            }
            Company company = await data.Companies
                .Include(c => c.Sellers)
                .FirstAsync(c => c.Id == companyId);

            if (company != null)
            {
                CompanyOverviewViewModel companyOverviewViewModel = new CompanyOverviewViewModel()
                {
                    Id = companyId,
                    Name = company.Name,
                    Address = company.Address,
                    Sellers = company.Sellers
                    .OrderByDescending(s => s.IsOwner)
                    .Select(s => new SellerViewModel()
                    {
                        Id = s.Id,
                        UserName = s.FirstName + " " + s.LastName,
                        PhoneNumber = s.PhoneNumber,
                        Position = s.IsOwner == true ? "Owner" : "Employee"
                    })
                    .ToList()
                };
                return companyOverviewViewModel;
            }

            return null;
        }
    }
}
