namespace AutoPartsShop.Web.ViewModels.Vehicle
{
    using AutoPartsShop.Web.ViewModels.Part;

    public class VehicleDetailsViewModel
    {
        public VehicleDetailsViewModel()
        {
            this.Parts = new HashSet<VehiclePartsViewModel>();
        }

        public Guid Id { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Year { get; set; } = null!;
        public Guid CompanyId { get; set; }
        public string Modification { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public ICollection<VehiclePartsViewModel> Parts { get; set; } = null!;
    }
}
