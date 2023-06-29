
using AutoPartsShop.Web.ViewModels.Seller;

namespace AutoPartsShop.Web.ViewModels.Company
{
    public class CompanyOverviewViewModel
    {
        public CompanyOverviewViewModel()
        {
            this.Sellers = new HashSet<SellerViewModel>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public ICollection<SellerViewModel> Sellers { get; set; } = null!;
    }
}
