using System.ComponentModel.DataAnnotations;

namespace AutoPartsShop.Data.Models
{
    using static AutoPartsShop.Common.EntityValidationConstants.Company;
    public class Company
    {
        public Company()
        {
            this.Id = Guid.NewGuid();
            this.Sellers = new HashSet<Seller>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(CompanyNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(CompanyAddressMaxLength)]
        public string Address { get; set; } = null!;

        public ICollection<Seller> Sellers { get; set; } = null!;
    }
}
