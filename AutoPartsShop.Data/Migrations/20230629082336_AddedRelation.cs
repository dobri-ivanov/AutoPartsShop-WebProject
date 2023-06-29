using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPartsShop.Data.Migrations
{
    public partial class AddedRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("c5c7ae4b-4f80-4f6b-9e58-c95ca5259df3"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("cf795f85-6acd-496b-b366-460069b300db"));

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "VehicleId" },
                values: new object[] { new Guid("2f858184-e0e5-4e0f-9fd2-d5251eb30152"), "In good condition!", "https://www.masterparts.com/wp-content/uploads/2020/07/clutch_kit.jpg", "Clutch", 250m, new Guid("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c") });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "VehicleId" },
                values: new object[] { new Guid("eb84385d-a952-4d29-899b-607dbe1d3227"), "In bad condition!", "https://www.hella.com/partnerworld/assets/images/10032598a.jpg", "Braking pads", 60m, new Guid("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("2f858184-e0e5-4e0f-9fd2-d5251eb30152"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("eb84385d-a952-4d29-899b-607dbe1d3227"));

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "VehicleId" },
                values: new object[] { new Guid("c5c7ae4b-4f80-4f6b-9e58-c95ca5259df3"), "In good condition!", "https://www.masterparts.com/wp-content/uploads/2020/07/clutch_kit.jpg", "Clutch", 250m, new Guid("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c") });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "VehicleId" },
                values: new object[] { new Guid("cf795f85-6acd-496b-b366-460069b300db"), "In bad condition!", "https://www.hella.com/partnerworld/assets/images/10032598a.jpg", "Braking pads", 60m, new Guid("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c") });
        }
    }
}
