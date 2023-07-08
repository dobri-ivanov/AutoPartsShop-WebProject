using AutoPartsShop.Web.ViewModels.Vehicle;

namespace AutoPartsShop.Services.Data.Interfaces
{
    public interface IVehicleService
    {
        public Task Add(VehicleFormModel model);
    }
}
