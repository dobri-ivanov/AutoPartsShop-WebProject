namespace AutoPartsShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using AutoPartsShop.Data.Models;

    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(GenerateUsers());
        }

        private ApplicationUser[] GenerateUsers()
        {
            ApplicationUser[] users = new ApplicationUser[2];

            users[0] = new ApplicationUser()
            {
                //Email - pesho@abv.bg
                //Password - 123456

                Id = Guid.Parse("C66B7420-2AC0-47D9-9161-08DB770024D4"),
                Email = "pesho@abv.bg",
                NormalizedEmail = "PESHO@ABV.BG",
                UserName = "pesho@abv.bg",
                NormalizedUserName = "PESHO@ABV.BG",
                PasswordHash = "AQAAAAEAACcQAAAAEAs248g2DP9+bskpiionTEtPy20lJDcxeZ4kKzB+0Pxuv/88YQtVqclKzpb8apJYlg==",
                SecurityStamp = "MTXMNKMAVNOYDZLTBRTXNNVAKYBB4K4I",
                ConcurrencyStamp = "c42d267f-67b9-484b-ba42-09c8c47316f9"
            };

            users[1] = new ApplicationUser()
            {
                //Email - gosho@abv.bg
                //Password - 123456

                Id = Guid.Parse("8D9C378A-2859-4A3D-9162-08DB770024D4"),
                Email = "gosho@abv.bg",
                NormalizedEmail = "GOSHO@ABV.BG",
                UserName = "gosho@abv.bg",
                NormalizedUserName = "GOSHO@ABV.BG",
                PasswordHash = "AQAAAAEAACcQAAAAEMupxsqyc3A+ipQ5NrTfBube2JGxL+e0wo9+8vgu9EtYEaeqQ/ZW6rDx6lpfaGlFgA==",
                SecurityStamp = "ONYDIZTG3AL5FFLT57HFQP3WTX5U2VJR",
                ConcurrencyStamp = "2b8cdc30-1963-4c13-bc6c-1a22585fb784"
            };

            return users;
        }
    }
}
