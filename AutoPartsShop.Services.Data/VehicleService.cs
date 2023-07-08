using AutoPartsShop.Data.Models;
using AutoPartsShop.Services.Data.Interfaces;
using AutoPartsShop.Web.Data;
using AutoPartsShop.Web.ViewModels.Vehicle;
using AutoPartsShop.Web.ViewModels.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsShop.Services.Data
{
    public class VehicleService : IVehicleService
    {
        private readonly AutoPartsDbContext data;
        public VehicleService(AutoPartsDbContext context)
        {
            data = context;
        }
        public async Task AddAsync(VehicleFormModel model)
        {
            Vehicle vehicle = new Vehicle()
            {
                Make = model.Make,
                Model = model.Model,
                CategoryId = model.CategoryId,
                CompanyId = model.CompanyId,
                ProductionDate = model.ProductionDate,
                Modification = model.Modification,
                ImageUrl = model.ImageUrl
            };

            await data.Vehicles.AddAsync(vehicle);
            await data.SaveChangesAsync();
        }

        public async Task DeleteSaveChangesAsync(Guid id)
        {
            var vehicle = await data.Vehicles.FirstOrDefaultAsync(v => v.Id == id);

            if (vehicle != null)
            {
                data.Vehicles.Remove(vehicle);
                await data.SaveChangesAsync();
            }
        }

        public async Task EditSaveChanges(Guid id, VehicleFormModel formModel)
        {
            var vehicle = await data.Vehicles.FirstOrDefaultAsync(v => v.Id == id);

            if (vehicle != null)
            {
                vehicle.Make = formModel.Make;
                vehicle.Model = formModel.Model;
                vehicle.CategoryId = formModel.CategoryId;
                vehicle.ProductionDate = formModel.ProductionDate;
                vehicle.Modification = formModel.Modification;
                vehicle.ImageUrl = formModel.ImageUrl;
            }

            await data.SaveChangesAsync();
        }

        public async Task<ICollection<VehicleViewModel>> FindAllAsync(Guid id)
        {
            var vehicles = await data.Vehicles
                .Where(v => v.CompanyId == id)
                .Select(v => new VehicleViewModel()
                {
                    Id = v.Id,
                    MakeAndModel = v.Make + " " + v.Model,
                    Modification = v.Modification,
                    ImageUrl = v.ImageUrl
                })
                .ToListAsync();

            return vehicles;
        }

        public async Task<VehicleDeleteViewModel> GetDataForDeleteAsync(Guid id)
        {
            var vehicle = await data.Vehicles.FirstOrDefaultAsync(vehicle => vehicle.Id == id);

            if (vehicle != null)
            {
                VehicleDeleteViewModel viewModel = new VehicleDeleteViewModel()
                {
                    MakeAndModel = vehicle.Make,
                    Model = vehicle.Model,
                    Year = vehicle.ProductionDate,
                    Modification = vehicle.Modification,
                    Id = vehicle.Id,
                    ImageUrl = vehicle.ImageUrl,
                    CompanyId = vehicle.CompanyId
                    
                };

                return viewModel;
            }

            return null!;
        }

        public async Task<VehicleFormModel> GetDataForEditAsync(Guid id)
        {
            if (id != Guid.Empty)
            {
                var v = await data.Vehicles
                    .FirstAsync(v => v.Id == id);

                VehicleFormModel formModel = new VehicleFormModel()
                {
                    Make = v.Make,
                    Model = v.Model,
                    CategoryId = v.CategoryId,
                    CompanyId = v.CompanyId,
                    ProductionDate = v.ProductionDate,
                    Modification = v.Modification,
                    ImageUrl = v.ImageUrl
                };
                return formModel;
            }
            return null;
        }

        public async Task<ICollection<VehicleChooseViewModel>> SelectVehicles(Guid id)
        {
            ICollection<VehicleChooseViewModel> vehicles = await data.Vehicles
                .Where(v => v.CompanyId == id)
                .Select(v => new VehicleChooseViewModel()
                {
                    Id = v.Id,
                    Name = v.Make + " " + v.Model + " " + v.ProductionDate + " " + v.Modification,
                })
                .ToListAsync();

            return vehicles;
        }
    }
}
