namespace AutoPartsShop.Services.Data.Interfaces
{
    using AutoPartsShop.Web.ViewModels.Vehicle;
    
    public interface IVehicleService
    {
        public Task AddAsync(VehicleFormModel model);
        public Task<ICollection<VehicleViewModel>> FindAllAsync(Guid id);
        public Task<VehicleFormModel> GetDataForEditAsync(Guid id);
        public Task EditSaveChanges(Guid id, VehicleFormModel formModel);
        public Task<VehicleDeleteViewModel> GetDataForDeleteAsync(Guid id);
        public Task DeleteSaveChangesAsync(Guid id);
        public Task<ICollection<VehicleChooseViewModel>> SelectVehicles(Guid id);
        public Task<VehicleDetailsViewModel> VehicleDetailsAsync(Guid id);
    }
}
