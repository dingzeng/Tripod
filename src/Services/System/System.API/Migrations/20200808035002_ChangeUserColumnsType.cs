using Microsoft.EntityFrameworkCore.Migrations;

namespace System.API.Migrations
{
    public partial class ChangeUserColumnsType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Permission");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "User",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsLeaf",
                table: "Menu",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Permission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "IsLeaf",
                table: "Menu",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
