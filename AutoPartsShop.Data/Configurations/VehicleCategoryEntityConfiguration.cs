namespace AutoPartsShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    using Models;

    public class VehicleCategoryEntityConfiguration : IEntityTypeConfiguration<VehicleCategory>
    {
        public void Configure(EntityTypeBuilder<VehicleCategory> builder)
        {
            builder.HasData(GenerateCategories());
        }

        private VehicleCategory[] GenerateCategories()
        {
            ICollection<VehicleCategory> categories = new HashSet<VehicleCategory>();

            VehicleCategory vehicleCategory = new VehicleCategory()
            {
                Id = 1,
                Name = "Car"
            };
            categories.Add(vehicleCategory);

            vehicleCategory = new VehicleCategory()
            {
                Id = 2,
                Name = "Truck"
            };
            categories.Add(vehicleCategory);

            vehicleCategory = new VehicleCategory()
            {
                Id = 3,
                Name = "Motorcycle"
            };
            categories.Add(vehicleCategory);

            return categories.ToArray();
        }
    }
}
