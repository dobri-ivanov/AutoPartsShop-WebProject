namespace AutoPartsShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    using Models;

    internal class VehicleEntityConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasData(GenerateVehicles());
        }

        private Vehicle[] GenerateVehicles()
        {
            ICollection<Vehicle> vehicles = new HashSet<Vehicle>();

            Vehicle vehicle = new Vehicle()
            {
                Id = Guid.Parse("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c"),
                Make = "Audi",
                Model = "A6",
                CategoryId = 1,
                ProductionDate = new DateTime(2015, 01, 01),
                Modification = "3.0 TDI 313hp",
                SellerId = Guid.Parse("9D91AA6F-75FA-44B3-BD1C-FB066AA5401C"),
                ImageUrl = "https://www.netcarshow.com/Audi-A6-2015.jpg",
            };
            vehicles.Add(vehicle);

            vehicle = new Vehicle()
            {
                Id = Guid.Parse("b44baa0a-a492-4564-862c-a85384d97d76"),
                Make = "BMW",
                Model = "530",
                CategoryId = 1,
                ProductionDate = new DateTime(2008, 01, 01),
                Modification = "3.0 214hp",
                SellerId = Guid.Parse("9D91AA6F-75FA-44B3-BD1C-FB066AA5401C"),
                ImageUrl = "https://www.auto-data.net/images/f126/BMW-5-Series-E60.jpg",
            };
            vehicles.Add(vehicle);

            return vehicles.ToArray();       
        }
    }
}
