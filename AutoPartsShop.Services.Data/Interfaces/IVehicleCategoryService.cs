namespace AutoPartsShop.Services.Data.Interfaces
{
    using AutoPartsShop.Web.Views.VehicleCategory;
    
    public interface IVehicleCategoryService
    {
        public Task<ICollection<VehicleCategoryViewModel>> AllAsync();

    }
}
