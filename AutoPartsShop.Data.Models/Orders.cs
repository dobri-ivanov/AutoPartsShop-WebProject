namespace AutoPartsShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static AutoPartsShop.Common.EntityValidationConstants.Orders;
    
    public class Orders
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(Part))]
        public Guid PartId { get; set; }
        public virtual Part Part { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        [MaxLength(OrderFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(OrderLastNameMaxLength)]
        public string LastName { get; set; } = null!;
       
        [Required]
        public string ContactPhoneNumber { get; set; } = null!;

        [Required]
        [MaxLength(OrderDeliveryAddressMaxLength)]
        public string DeliveryAddress { get; set; } = null!;
    }
}
