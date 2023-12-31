﻿namespace AutoPartsShop.Web.Data
{
    using System.Reflection;
    
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using AutoPartsShop.Data.Models;

    public class AutoPartsDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public AutoPartsDbContext(DbContextOptions<AutoPartsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Part> Parts { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<VehicleCategory> VehicleCategories { get; set; } = null!;
        public DbSet<Seller> Sellers { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Orders> Orders { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(AutoPartsDbContext)) ??
                                      Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            builder.Entity<Company>()
                .HasMany(c => c.Sellers)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId)
                .IsRequired();

            base.OnModelCreating(builder);
        }
    }
}