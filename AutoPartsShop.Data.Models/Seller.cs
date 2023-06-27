namespace AutoPartsShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static AutoPartsShop.Common.EntityValidationConstants.Seller;

    public class Seller
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(SellerPhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
    }
}
