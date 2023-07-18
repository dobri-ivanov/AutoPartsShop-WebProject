namespace AutoPartsShop.Web.ViewModels.Vehicle
{
    public class VehicleViewModel
    {
        public Guid Id { get; set; }
        public string MakeAndModel { get; set; } = null!;
        public string Modification { get; set; } = null!;
        public string? ImageUrl { get; set; } = null!;
    }
}
