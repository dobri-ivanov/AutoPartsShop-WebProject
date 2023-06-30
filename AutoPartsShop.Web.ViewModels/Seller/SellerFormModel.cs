namespace AutoPartsShop.Web.ViewModels.Seller
{
    using System.ComponentModel.DataAnnotations;
    using static AutoPartsShop.Common.EntityValidationConstants.Seller;

    public class SellerFormModel
    {
        public Guid Id { get; set; }

        [Required]
        public Guid Company { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(SellerFirstNameMaxLength, MinimumLength = SellerFirstNameMinLength, ErrorMessage = "Invalid first name!")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(SellerLastNameMaxLength, MinimumLength = SellerLastNameMinLength, ErrorMessage = "Invalid first name!")]
        public string LastName { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        public bool IsOwner { get; set; } = false;

    }
}
