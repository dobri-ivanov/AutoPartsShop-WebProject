using AutoPartsShop.Services.Data.Interfaces;
using AutoPartsShop.Web.Data;
using AutoPartsShop.Web.ViewModels.Part;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsShop.Services.Data
{
    public class PartService : IPartService
    {
        private readonly AutoPartsDbContext context;

        public PartService(AutoPartsDbContext data)
        {
                context = data;
        }
        public async Task<IEnumerable<PartViewModel>> All()
        {
            List<PartViewModel> parts = await context.Parts
               .Select(p => new PartViewModel()
               {
                   Name = p.Name,
                   Price = p.Price,
                   ImageUrl = p.ImageUrl,
                   Vehicle = String.Format($"{p.Vehicle.Make} {p.Vehicle.Model}"),
                   Seller = p.Vehicle.Company.Name
               })
               .ToListAsync();

            return parts;
        }
    }
}
