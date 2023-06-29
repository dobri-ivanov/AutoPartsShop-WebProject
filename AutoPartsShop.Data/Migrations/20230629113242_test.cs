using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPartsShop.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("2f858184-e0e5-4e0f-9fd2-d5251eb30152"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("eb84385d-a952-4d29-899b-607dbe1d3227"));

            migrationBuilder.DeleteData(
                table: "VehicleCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("b44baa0a-a492-4564-862c-a85384d97d76"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("89caa742-325e-4dbb-9176-d52f7706684a"));

            migrationBuilder.DeleteData(
                table: "VehicleCategories",
                keyColumn: "Id",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { new Guid("89caa742-325e-4dbb-9176-d52f7706684a"), "Bulgaria, Sofia", "MostAuto" });

            migrationBuilder.InsertData(
                table: "VehicleCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Car" },
                    { 2, "Truck" },
                    { 3, "Motorcycle" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CategoryId", "CompanyId", "ImageUrl", "Make", "Model", "Modification", "ProductionDate" },
                values: new object[] { new Guid("b44baa0a-a492-4564-862c-a85384d97d76"), 1, new Guid("89caa742-325e-4dbb-9176-d52f7706684a"), "https://www.auto-data.net/images/f126/BMW-5-Series-E60.jpg", "BMW", "530", "3.0 214hp", new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CategoryId", "CompanyId", "ImageUrl", "Make", "Model", "Modification", "ProductionDate" },
                values: new object[] { new Guid("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c"), 1, new Guid("89caa742-325e-4dbb-9176-d52f7706684a"), "https://www.netcarshow.com/Audi-A6-2015.jpg", "Audi", "A6", "3.0 TDI 313hp", new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "VehicleId" },
                values: new object[] { new Guid("2f858184-e0e5-4e0f-9fd2-d5251eb30152"), "In good condition!", "https://www.masterparts.com/wp-content/uploads/2020/07/clutch_kit.jpg", "Clutch", 250m, new Guid("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c") });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "VehicleId" },
                values: new object[] { new Guid("eb84385d-a952-4d29-899b-607dbe1d3227"), "In bad condition!", "https://www.hella.com/partnerworld/assets/images/10032598a.jpg", "Braking pads", 60m, new Guid("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c") });
        }
    }
}
