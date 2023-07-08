﻿using AutoPartsShop.Web.ViewModels.Vehicle;
using AutoPartsShop.Web.ViewModels.Vehicles;

namespace AutoPartsShop.Services.Data.Interfaces
{
    public interface IVehicleService
    {
        public Task AddAsync(VehicleFormModel model);
        public Task<ICollection<VehicleViewModel>> FindAllAsync(Guid id);
        public Task<VehicleFormModel> GetDataForEditAsync(Guid id);
        public Task EditSaveChanges(Guid id, VehicleFormModel formModel);
    }
}
