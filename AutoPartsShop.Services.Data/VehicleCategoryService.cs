using AutoPartsShop.Services.Data.Interfaces;
using AutoPartsShop.Web.Data;
using AutoPartsShop.Web.Views.VehicleCategory;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsShop.Services.Data
{
    internal class VehicleCategoryService : IVehicleCategoryService
    {
        private readonly AutoPartsDbContext data;
        public VehicleCategoryService(AutoPartsDbContext context)
        {
            data = context;
        }

        public async Task<ICollection<VehicleCategoryViewModel>> AllAsync()
        {
            var categories = await data.VehicleCategories
                .Select(c => new VehicleCategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return categories;
        }
    }
}
