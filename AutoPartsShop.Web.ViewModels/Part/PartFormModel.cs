using AutoPartsShop.Web.ViewModels.Vehicle;

namespace AutoPartsShop.Web.ViewModels.Part
{
    public class PartFormModel
    {
        public PartFormModel()
        {
            this.Vehicles = new HashSet<VehicleChooseViewModel>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
        public Guid VehicleId { get; set; }
        public Guid CompanyId { get; set; }
        public ICollection<VehicleChooseViewModel> Vehicles { get; set; } = null!;
    }
}
