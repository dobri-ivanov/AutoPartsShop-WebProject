namespace AutoPartsShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static AutoPartsShop.Common.EntityValidationConstants.VehicleCategory;
    
    public class VehicleCategory
    {
        public VehicleCategory()
        {
            this.Vehicles = new HashSet<Vehicle>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Vehicle> Vehicles { get; set; } = null!;
    }
}
