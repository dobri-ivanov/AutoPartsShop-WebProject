namespace AutoPartsShop.Web.ViewModels.Company
{
    using System.ComponentModel.DataAnnotations;
   
    using static AutoPartsShop.Common.EntityValidationConstants.Company;
    using static AutoPartsShop.Common.EntityValidationConstants.Seller;
    
    public class CompanyFormModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(CompanyNameMaxLength, MinimumLength = CompanyNameMinLength, ErrorMessage = $"Company name is invalid!")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(CompanyAddressMaxLength, MinimumLength = CompanyAddressMinLength, ErrorMessage = $"Address is invalid!")]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(SellerFirstNameMaxLength, MinimumLength = SellerFirstNameMinLength, ErrorMessage = "Invalid name!")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(SellerLastNameMaxLength, MinimumLength = SellerLastNameMinLength, ErrorMessage = "Invalid name!")]
        public string LastName { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        public Guid CurrentUserId { get; set; }


    }
}
