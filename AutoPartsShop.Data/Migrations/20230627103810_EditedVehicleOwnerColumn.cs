using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPartsShop.Data.Migrations
{
    public partial class EditedVehicleOwnerColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_OwnerId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Vehicles",
                newName: "SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_OwnerId",
                table: "Vehicles",
                newName: "IX_Vehicles_SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Sellers_SellerId",
                table: "Vehicles",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Sellers_SellerId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "Vehicles",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_SellerId",
                table: "Vehicles",
                newName: "IX_Vehicles_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_OwnerId",
                table: "Vehicles",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
