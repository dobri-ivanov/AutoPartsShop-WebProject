namespace AutoPartsShop.Data.Configurations
{
    using System;
    
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    using AutoPartsShop.Data.Models;

    class SellerEnityConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.HasData(GenerateSellers());
        }

        private Seller[] GenerateSellers()
        {
            Seller[] sellers = new Seller[2];

            sellers[0] = new Seller()
            {
                //Owner

                Id = Guid.NewGuid(),
                CompanyId = Guid.Parse("89caa742-325e-4dbb-9176-d52f7706684a"),
                UserId = Guid.Parse("c66b7420-2ac0-47d9-9161-08db770024d4"),
                IsOwner = true,
                PhoneNumber = "+35955466254",
                FirstName = "Pesho",
                LastName = "Georgiev"
            };

            sellers[1] = new Seller()
            {
                //Employee

                Id = Guid.NewGuid(),
                CompanyId = Guid.Parse("89caa742-325e-4dbb-9176-d52f7706684a"),
                UserId = Guid.Parse("8d9c378a-2859-4a3d-9162-08db770024d4"),
                IsOwner = false,
                PhoneNumber = "+35955586241",
                FirstName = "Gosho",
                LastName = "Iliev"
            };

            return sellers;
        }
    }
}
