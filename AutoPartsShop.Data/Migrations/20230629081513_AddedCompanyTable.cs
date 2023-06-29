using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPartsShop.Data.Migrations
{
    public partial class AddedCompanyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Sellers_SellerId",
                table: "Vehicles");

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("5b7640d7-5000-4b19-bdab-c5fbf8ec83b8"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("88be3d07-934d-40cc-9be0-1faeb71cf6ad"));

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "Vehicles",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_SellerId",
                table: "Vehicles",
                newName: "IX_Vehicles_CompanyId");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Parts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { new Guid("89caa742-325e-4dbb-9176-d52f7706684a"), "Bulgaria, Sofia", "MostAuto" });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "VehicleId" },
                values: new object[] { new Guid("145b7171-3c2f-42af-a9e4-d2ae4d9f2ef6"), "In bad condition!", "https://www.hella.com/partnerworld/assets/images/10032598a.jpg", "Braking pads", 60m, new Guid("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c") });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "VehicleId" },
                values: new object[] { new Guid("d07e9096-1f4f-4d0f-b4d6-1a2c3b140cf9"), "In good condition!", "https://www.masterparts.com/wp-content/uploads/2020/07/clutch_kit.jpg", "Clutch", 250m, new Guid("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c") });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("b44baa0a-a492-4564-862c-a85384d97d76"),
                column: "CompanyId",
                value: new Guid("89caa742-325e-4dbb-9176-d52f7706684a"));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c"),
                column: "CompanyId",
                value: new Guid("89caa742-325e-4dbb-9176-d52f7706684a"));

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Companies_CompanyId",
                table: "Vehicles",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Companies_CompanyId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("145b7171-3c2f-42af-a9e4-d2ae4d9f2ef6"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("d07e9096-1f4f-4d0f-b4d6-1a2c3b140cf9"));

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Vehicles",
                newName: "SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_CompanyId",
                table: "Vehicles",
                newName: "IX_Vehicles_SellerId");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Parts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("5b7640d7-5000-4b19-bdab-c5fbf8ec83b8"), "In bad condition!", "https://www.hella.com/partnerworld/assets/images/10032598a.jpg", "Braking pads", 60m, new Guid("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c") },
                    { new Guid("88be3d07-934d-40cc-9be0-1faeb71cf6ad"), "In good condition!", "https://www.masterparts.com/wp-content/uploads/2020/07/clutch_kit.jpg", "Clutch", 250m, new Guid("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c") }
                });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("b44baa0a-a492-4564-862c-a85384d97d76"),
                column: "SellerId",
                value: new Guid("9d91aa6f-75fa-44b3-bd1c-fb066aa5401c"));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("bb9e424a-7dbe-4f42-83e5-3ee32a8a301c"),
                column: "SellerId",
                value: new Guid("9d91aa6f-75fa-44b3-bd1c-fb066aa5401c"));

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Sellers_SellerId",
                table: "Vehicles",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
