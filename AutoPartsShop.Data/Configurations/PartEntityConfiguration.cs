namespace AutoPartsShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    using Models;
    
    internal class PartEntityConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.HasData(GenerateParts());
        }

        private Part[] GenerateParts()
        {
            ICollection<Part> parts = new HashSet<Part>();

            Part part = new Part()
            {
                Name = "Clutch",
                Description = "In good condition!",
                Price = 250,
                VehicleId = Guid.Parse("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c"),
                ImageUrl = "https://www.masterparts.com/wp-content/uploads/2020/07/clutch_kit.jpg"
            };
            parts.Add(part);

            part = new Part()
            {
                Name = "Braking pads",
                Description = "In bad condition!",
                Price = 60,
                VehicleId = Guid.Parse("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c"),
                ImageUrl = "https://www.hella.com/partnerworld/assets/images/10032598a.jpg"
            };
            parts.Add(part);

            return parts.ToArray();
        }
    }
}
