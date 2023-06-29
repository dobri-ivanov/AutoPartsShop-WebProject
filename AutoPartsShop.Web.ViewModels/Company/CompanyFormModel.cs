namespace AutoPartsShop.Web.ViewModels.Company
{
    using System.ComponentModel.DataAnnotations;
   
    using static AutoPartsShop.Common.EntityValidationConstants.Company;
    
    public class CompanyFormModel
    {
        [Required]
        [StringLength(CompanyNameMaxLength, MinimumLength = CompanyNameMinLength, ErrorMessage = $"Copmany name is invalid!")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(CompanyAddressMaxLength, MinimumLength = CompanyAddressMinLength, ErrorMessage = $"Address is invalid!")]
        public string Address { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        public Guid CurrentUserId { get; set; }


    }
}
