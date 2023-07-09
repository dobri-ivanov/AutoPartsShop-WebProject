namespace AutoPartsShop.Web.ViewModels.Part
{
    using System.ComponentModel.DataAnnotations;

    using AutoPartsShop.Web.ViewModels.Vehicle;
    using static AutoPartsShop.Common.EntityValidationConstants.Part;

    public class PartFormModel
    {
        public PartFormModel()
        {
            this.Vehicles = new HashSet<VehicleChooseViewModel>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(PartNameMaxLength, MinimumLength = PartNameMinLength)]
        public string Name { get; set; } = null!;

        [MaxLength(PartDescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        public Guid VehicleId { get; set; }

        public Guid CompanyId { get; set; }

        public ICollection<VehicleChooseViewModel> Vehicles { get; set; } = null!;
    }
}
