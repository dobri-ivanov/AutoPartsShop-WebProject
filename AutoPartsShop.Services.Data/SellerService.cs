namespace AutoPartsShop.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    
    using AutoPartsShop.Data.Models;
    using AutoPartsShop.Web.Data;
    using Interfaces;
    
    public class SellerService : ISellerService
    {
        private readonly AutoPartsDbContext data;
        public SellerService(AutoPartsDbContext context)
        {
            data = context;
        }

        public async Task<Guid> CompanyId(Guid userId)
        {
            Seller seller = await data.Sellers.FirstAsync(s => s.UserId == userId);
            return seller.CompanyId;
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
    }
}
