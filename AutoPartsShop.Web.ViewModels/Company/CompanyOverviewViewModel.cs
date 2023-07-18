namespace AutoPartsShop.Web.ViewModels.Company
{
    using AutoPartsShop.Web.ViewModels.Seller;
    using AutoPartsShop.Web.ViewModels.Vehicle;

    public class CompanyOverviewViewModel
    {
        public CompanyOverviewViewModel()
        {
            this.Sellers = new HashSet<SellerViewModel>();
            this.Vehicles = new HashSet<VehicleViewModel>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public ICollection<SellerViewModel> Sellers { get; set; } = null!;
        public ICollection<VehicleViewModel> Vehicles { get; set; } = null!;
    }
}
