using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPartsShop.Data.Migrations
{
    public partial class SeedingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VehicleCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Car" });

            migrationBuilder.InsertData(
                table: "VehicleCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Truck" });

            migrationBuilder.InsertData(
                table: "VehicleCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Motorcycle" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "Make", "Model", "Modification", "ProductionDate", "SellerId" },
                values: new object[] { new Guid("b44baa0a-a492-4564-862c-a85384d97d76"), 1, "https://www.auto-data.net/images/f126/BMW-5-Series-E60.jpg", "BMW", "530", "3.0 214hp", new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9d91aa6f-75fa-44b3-bd1c-fb066aa5401c") });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "Make", "Model", "Modification", "ProductionDate", "SellerId" },
                values: new object[] { new Guid("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c"), 1, "https://www.netcarshow.com/Audi-A6-2015.jpg", "Audi", "A6", "3.0 TDI 313hp", new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9d91aa6f-75fa-44b3-bd1c-fb066aa5401c") });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "VehicleId" },
                values: new object[] { new Guid("5b7640d7-5000-4b19-bdab-c5fbf8ec83b8"), "In bad condition!", "https://www.hella.com/partnerworld/assets/images/10032598a.jpg", "Braking pads", 60m, new Guid("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c") });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "VehicleId" },
                values: new object[] { new Guid("88be3d07-934d-40cc-9be0-1faeb71cf6ad"), "In good condition!", "https://www.masterparts.com/wp-content/uploads/2020/07/clutch_kit.jpg", "Clutch", 250m, new Guid("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("5b7640d7-5000-4b19-bdab-c5fbf8ec83b8"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("88be3d07-934d-40cc-9be0-1faeb71cf6ad"));

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
                table: "VehicleCategories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
