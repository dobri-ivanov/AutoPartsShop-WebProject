namespace AutoPartsShop.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using AutoPartsShop.Data.Models;
    using AutoPartsShop.Web.Data;
    using Interfaces;
    using AutoPartsShop.Web.ViewModels.Seller;

    public class SellerService : ISellerService
    {
        private readonly AutoPartsDbContext data;
        public SellerService(AutoPartsDbContext context)
        {
            data = context;
        }

        public async Task AddEmployeeAsync(SellerFormModel formModel)
        {
            Seller employee = new Seller()
            {
                FirstName = formModel.FirstName,
                LastName = formModel.LastName,
                PhoneNumber = formModel.PhoneNumber,
                CompanyId = formModel.Company,
                UserId = formModel.UserId,
                IsOwner = formModel.IsOwner
            };

            await data.Sellers.AddAsync(employee);
            await data.SaveChangesAsync();
        }

        public async Task<Guid> CompanyId(Guid userId)
        {
            Seller seller = await data.Sellers.FirstAsync(s => s.UserId == userId);
            if (seller != null)
            {
                return seller.CompanyId;
            }

            return Guid.Empty;
        }

        public async Task<Guid> CompanyIdBySellerId(Guid sellerId)
        {
            Seller seller = await data.Sellers.FirstAsync(s => s.Id == sellerId);
            if (seller != null)
            {
                return seller.CompanyId;
            }

            return Guid.Empty;
        }

        public async Task DeleteAsync(Guid sellerId)
        {
            Seller seller = await data.Sellers.FirstAsync(s => s.Id == sellerId);

            if (seller != null)
            {
                data.Sellers.Remove(seller);
            }

            await data.SaveChangesAsync();
        }

        public async Task<SellerFormModel> DeleteDataAsync(Guid sellerId)
        {
            Seller seller = await data.Sellers.FirstAsync(s => s.Id == sellerId);

            if (seller == null)
            {
                return null;
            }

            ApplicationUser user = await data.Users.Where(u => u.Id == seller.UserId).FirstAsync();
            SellerFormModel formModel = new SellerFormModel()
            {
                Id = sellerId,
                Email = user.Email,
                FirstName = seller.FirstName,
                Company = seller.CompanyId,
                LastName = seller.LastName,
                PhoneNumber = seller.PhoneNumber,
                IsOwner = seller.IsOwner
            };

            return formModel;
        }

        public async Task EditAsync(Guid sellerId, SellerEditFormModel formModel)
        {
            Seller seller = await data.Sellers.FirstAsync(s => s.Id == sellerId);

            if (seller != null)
            {
                seller.FirstName = formModel.FirstName;
                seller.LastName = formModel.LastName;
                seller.PhoneNumber = formModel.PhoneNumber;
                seller.IsOwner = formModel.IsOwner;
            }

            await data.SaveChangesAsync();
        }

        public async Task<SellerEditFormModel> EditDataAsync(Guid sellerId)
        {
            Seller seller = await data.Sellers.FirstAsync(s => s.Id == sellerId);

            if (seller == null)
            {
                return null;
            }

            SellerEditFormModel formModel = new SellerEditFormModel()
            {
                Id = sellerId,
                FirstName = seller.FirstName,
                LastName = seller.LastName,
                PhoneNumber = seller.PhoneNumber,
                IsOwner = seller.IsOwner
            };

            return formModel;
        }

        public async Task<bool> IsOwner(Guid userId, Guid companyId)
        {
            if (await IsSeller(userId))
            {
                Seller seller = await data.Sellers.FirstAsync(s => s.UserId == userId);

                if (seller.IsOwner && seller.CompanyId == companyId) return true;
            }

            return false;
        }

        public async Task<bool> IsSeller(Guid userId)
        {

            return await data.Sellers.AnyAsync(s => s.UserId == userId);

        }

        public async Task<bool> IsSeller(Guid userId, Guid companyId)
        {

            return await data.Sellers.AnyAsync(s => s.UserId == userId && s.CompanyId == companyId);

        }

        public async Task<Guid> IsValidEmployee(string email)
        {
            if (email == null) return Guid.Empty;

            var user = await data.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return Guid.Empty;
            if (await IsSeller(user.Id)) return Guid.Empty;

            return user.Id;
        }
    }
}
