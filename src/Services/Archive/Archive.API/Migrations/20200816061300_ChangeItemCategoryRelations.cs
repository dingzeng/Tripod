using Microsoft.EntityFrameworkCore.Migrations;

namespace Archive.API.Migrations
{
    public partial class ChangeItemCategoryRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Category_CategoryId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_CategoryId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Item");

            migrationBuilder.AddColumn<string>(
                name: "Category1Id",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category2Id",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category3Id",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryId1",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryId2",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryId3",
                table: "Item",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_Category1Id",
                table: "Item",
                column: "Category1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Category2Id",
                table: "Item",
                column: "Category2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Category3Id",
                table: "Item",
                column: "Category3Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Category_Category1Id",
                table: "Item",
                column: "Category1Id",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Category_Category2Id",
                table: "Item",
                column: "Category2Id",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Category_Category3Id",
                table: "Item",
                column: "Category3Id",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Category_Category1Id",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Category_Category2Id",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Category_Category3Id",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_Category1Id",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_Category2Id",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_Category3Id",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Category1Id",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Category2Id",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Category3Id",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CategoryId2",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CategoryId3",
                table: "Item");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Item",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CategoryId",
                table: "Item",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Category_CategoryId",
                table: "Item",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
