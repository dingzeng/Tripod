using Microsoft.EntityFrameworkCore.Migrations;

namespace Archive.API.Migrations
{
    public partial class AddBranchPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Branch",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Branch");
        }
    }
}
