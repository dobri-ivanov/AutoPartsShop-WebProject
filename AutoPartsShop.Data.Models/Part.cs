﻿namespace AutoPartsShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static AutoPartsShop.Common.EntityValidationConstants.Part;
    
    internal class Part
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(PartNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(PartDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey(nameof(Vehicle))]
        public Guid VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; } = null!;

    }
}
