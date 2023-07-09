namespace AutoPartsShop.Web.ViewModels.Part
{
    public class VehiclePartsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
