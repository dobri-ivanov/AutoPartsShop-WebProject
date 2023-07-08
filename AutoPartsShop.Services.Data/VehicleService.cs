using AutoPartsShop.Data.Models;
using AutoPartsShop.Services.Data.Interfaces;
using AutoPartsShop.Web.Data;
using AutoPartsShop.Web.ViewModels.Vehicle;

namespace AutoPartsShop.Services.Data
{
    public class VehicleService : IVehicleService
    {
        private readonly AutoPartsDbContext data;
        public VehicleService(AutoPartsDbContext context)
        {
            data = context;
        }
        public async Task Add(VehicleFormModel model)
        {
            Vehicle vehicle = new Vehicle()
            {
                Make = model.Make,
                Model = model.Model,
                CategoryId = model.CategoryId,
                ProductionDate = DateTime.Parse(model.ProductionDate),
                Modification = model.Modification,
                ImageUrl = model.ImageUrl
            };

            await data.Vehicles.AddAsync(vehicle);
            await data.SaveChangesAsync();
        }
    }
}
