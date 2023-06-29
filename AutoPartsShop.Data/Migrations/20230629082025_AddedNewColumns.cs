using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPartsShop.Data.Migrations
{
    public partial class AddedNewColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("145b7171-3c2f-42af-a9e4-d2ae4d9f2ef6"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("d07e9096-1f4f-4d0f-b4d6-1a2c3b140cf9"));

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Sellers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsOwner",
                table: "Sellers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "VehicleId" },
                values: new object[] { new Guid("c5c7ae4b-4f80-4f6b-9e58-c95ca5259df3"), "In good condition!", "https://www.masterparts.com/wp-content/uploads/2020/07/clutch_kit.jpg", "Clutch", 250m, new Guid("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c") });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "VehicleId" },
                values: new object[] { new Guid("cf795f85-6acd-496b-b366-460069b300db"), "In bad condition!", "https://www.hella.com/partnerworld/assets/images/10032598a.jpg", "Braking pads", 60m, new Guid("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c") });

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_CompanyId",
                table: "Sellers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Companies_CompanyId",
                table: "Sellers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Companies_CompanyId",
                table: "Sellers");

            migrationBuilder.DropIndex(
                name: "IX_Sellers_CompanyId",
                table: "Sellers");

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("c5c7ae4b-4f80-4f6b-9e58-c95ca5259df3"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("cf795f85-6acd-496b-b366-460069b300db"));

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "IsOwner",
                table: "Sellers");

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "VehicleId" },
                values: new object[] { new Guid("145b7171-3c2f-42af-a9e4-d2ae4d9f2ef6"), "In bad condition!", "https://www.hella.com/partnerworld/assets/images/10032598a.jpg", "Braking pads", 60m, new Guid("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c") });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "VehicleId" },
                values: new object[] { new Guid("d07e9096-1f4f-4d0f-b4d6-1a2c3b140cf9"), "In good condition!", "https://www.masterparts.com/wp-content/uploads/2020/07/clutch_kit.jpg", "Clutch", 250m, new Guid("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c") });
        }
    }
}
