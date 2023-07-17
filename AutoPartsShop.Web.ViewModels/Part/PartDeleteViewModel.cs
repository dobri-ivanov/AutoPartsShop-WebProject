namespace AutoPartsShop.Web.ViewModels.Part
{
    public class PartDeleteViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public string Vehicle { get; set; } = null!;
    }
}
