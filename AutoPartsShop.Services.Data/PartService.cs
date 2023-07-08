namespace AutoPartsShop.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    
    using AutoPartsShop.Services.Data.Interfaces;
    using AutoPartsShop.Web.Data;
    using AutoPartsShop.Web.ViewModels.Part;
    using AutoPartsShop.Data.Models;

    public class PartService : IPartService
    {
        private readonly AutoPartsDbContext data;

        public PartService(AutoPartsDbContext context)
        {
                data = context;
        }

        public async Task AddSaveChangesAsync(PartFormModel formModel)
        {
            Part part = new Part()
            {
                Name = formModel.Name,
                Description = formModel.Description,
                Price = formModel.Price,
                VehicleId = formModel.VehicleId,
                ImageUrl = formModel.ImageUrl,
            };

            await data.Parts.AddAsync(part);
            await data.SaveChangesAsync();
        }

        public async Task<IEnumerable<PartViewModel>> All()
        {
            List<PartViewModel> parts = await data.Parts
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
