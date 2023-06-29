namespace AutoPartsShop.Data.Configurations
{
    using AutoPartsShop.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CompanyEntityConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(GenerateCompany());
        }

        private Company GenerateCompany()
        {
            Company company = new Company()
            {
                Id = Guid.Parse("89caa742-325e-4dbb-9176-d52f7706684a"),
                Name = "MostAuto",
                Address = "Bulgaria, Sofia"
            };

            return company;
        }
    }
}
