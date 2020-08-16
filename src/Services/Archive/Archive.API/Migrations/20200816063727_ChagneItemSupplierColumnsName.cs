using Microsoft.EntityFrameworkCore.Migrations;

namespace Archive.API.Migrations
{
    public partial class ChagneItemSupplierColumnsName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimarySupplierId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "PrimarySupplierName",
                table: "Item");

            migrationBuilder.AddColumn<string>(
                name: "SupplierId",
                table: "Item",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupplierName",
                table: "Item",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "SupplierName",
                table: "Item");

            migrationBuilder.AddColumn<string>(
                name: "PrimarySupplierId",
                table: "Item",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrimarySupplierName",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
