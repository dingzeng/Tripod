using Microsoft.EntityFrameworkCore.Migrations;

namespace Archive.API.Migrations
{
    public partial class FixBranchGroupMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_BranchGroup_BranchGroupId",
                table: "Branch");

            migrationBuilder.DropIndex(
                name: "IX_Branch_BranchGroupId",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "BranchGroupId",
                table: "Branch");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchGroupId",
                table: "Branch",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branch_BranchGroupId",
                table: "Branch",
                column: "BranchGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_BranchGroup_BranchGroupId",
                table: "Branch",
                column: "BranchGroupId",
                principalTable: "BranchGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
