namespace AutoPartsShop.Web.ViewModels.Part
{
    public class PartViewModel
    {
        public string ImageUrl { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Vehicle { get; set; } = null!;
        public string Seller { get; set; } = null!;
    }
}
