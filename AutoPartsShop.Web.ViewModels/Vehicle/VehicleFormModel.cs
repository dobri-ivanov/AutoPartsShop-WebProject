namespace AutoPartsShop.Web.ViewModels.Vehicle
{
    using System.ComponentModel.DataAnnotations;
    
    using AutoPartsShop.Web.Views.VehicleCategory;
    
    using static AutoPartsShop.Common.EntityValidationConstants.Vehicle;
    
    public class VehicleFormModel
    {
        [Required]
        [StringLength(VehicleMakeMaxLength, MinimumLength = VehicleMakeMinLength)]
        public string Make { get; set; } = null!;
        [Required]
        [StringLength(VehicleModelMaxLength, MinimumLength = VehicleModelMinLength)]
        public string Model { get; set; } = null!;
        [Required]
        [StringLength(VehicleProductionYearMaxLength, MinimumLength = VehicleProductionYearMinLength)]
        public string ProductionDate { get; set; } = null!;
        [Required]
        [StringLength(VehicleModificationMaxLength, MinimumLength = VehicleModificationMinLength)]
        public string Modification { get; set; } = null!;

        public Guid CompanyId { get; set; }

        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public ICollection<VehicleCategoryViewModel>? Categories { get; set; }

    }
}
