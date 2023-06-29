namespace AutoPartsShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    using static AutoPartsShop.Common.EntityValidationConstants.Vehicle;
    
    public class Vehicle
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(VehicleMakeMaxLength)]
        public string Make { get; set; } = null!;

        [Required]
        [MaxLength(VehicleModelMaxLength)]
        public string Model { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(VehicleCategory))]
        public int CategoryId { get; set; }
        public virtual VehicleCategory VehicleCategory { get; set; } = null!;

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        [MaxLength(VehicleModificationMaxLength)]
        public string Modification { get; set; } = null!;

        public virtual ICollection<Part> Parts { get; set; } = null!;

    }
}
