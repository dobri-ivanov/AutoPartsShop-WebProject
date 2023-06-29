using AutoPartsShop.Data.Models;
using AutoPartsShop.Services.Data.Interfaces;
using AutoPartsShop.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsShop.Services.Data
{
    public class SellerService : ISellerService
    {
        private readonly AutoPartsDbContext data;
        public SellerService(AutoPartsDbContext context)
        {
            data = context;
        }

        public async Task<Guid> CompanyId(Guid userId)
        {
            Seller? seller = await data.Sellers.FirstOrDefaultAsync(s => s.UserId == userId);
            return seller.CompanyId;
        }

        public async Task<bool> IsSeller(Guid userId)
        {
            return await data.Sellers.AnyAsync(s => s.UserId == userId);
        }
    }
}
