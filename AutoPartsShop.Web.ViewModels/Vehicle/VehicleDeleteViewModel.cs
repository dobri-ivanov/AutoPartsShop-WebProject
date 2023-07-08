using AutoPartsShop.Web.ViewModels.Vehicles;

namespace AutoPartsShop.Web.ViewModels.Vehicle
{
    public class VehicleDeleteViewModel : VehicleViewModel
    {
        public string Model { get; set; } = null!;
        public string Year { get; set; } = null!;
        public Guid CompanyId { get; set; }
    }
}
