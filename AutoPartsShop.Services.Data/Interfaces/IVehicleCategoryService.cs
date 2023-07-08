using AutoPartsShop.Web.Views.VehicleCategory;

namespace AutoPartsShop.Services.Data.Interfaces
{
    public interface IVehicleCategoryService
    {
        public Task<ICollection<VehicleCategoryViewModel>> AllAsync();
        
    }
}
