namespace AutoPartsShop.Web
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using AutoPartsShop.Data.Models;
    using AutoPartsShop.Services.Data.Interfaces;
    using Infrastructure.Extensions;

    public class Program
    {

        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            string connectionString =
                builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<AutoPartsDbContext>(options =>
                options.UseSqlServer(connectionString));

           builder.Services.AddApplicationServices(typeof(IPartService));
           builder.Services.AddApplicationServices(typeof(ICompanyService));
           builder.Services.AddApplicationServices(typeof(ISellerService));
           builder.Services.AddApplicationServices(typeof(IVehicleCategoryService));
           builder.Services.AddApplicationServices(typeof(IOrderService));

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount =
                         builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                options.Password.RequireLowercase =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireUppercase =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequireNonAlphanumeric =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequiredLength =
                    builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
            })

                .AddEntityFrameworkStores<AutoPartsDbContext>();

            builder.Services.AddControllersWithViews();

            WebApplication app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                //app.UseMigrationsEndPoint();
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

                app.UseHsts();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            app.Run();
        }
    }
}