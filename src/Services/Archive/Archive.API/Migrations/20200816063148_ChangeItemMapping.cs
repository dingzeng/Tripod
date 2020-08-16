using Microsoft.EntityFrameworkCore.Migrations;

namespace Archive.API.Migrations
{
    public partial class ChangeItemMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId3",
                table: "Item",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId2",
                table: "Item",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId1",
                table: "Item",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_CategoryId1",
                table: "Item",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CategoryId2",
                table: "Item",
                column: "CategoryId2");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CategoryId3",
                table: "Item",
                column: "CategoryId3");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Category_CategoryId1",
                table: "Item",
                column: "CategoryId1",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Category_CategoryId2",
                table: "Item",
                column: "CategoryId2",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Category_CategoryId3",
                table: "Item",
                column: "CategoryId3",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Category_CategoryId1",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Category_CategoryId2",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Category_CategoryId3",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_CategoryId1",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_CategoryId2",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_CategoryId3",
                table: "Item");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId3",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId2",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId1",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category1Id",
                table: "Item",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category2Id",
                table: "Item",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category3Id",
                table: "Item",
                type: "nvarchar(450)",
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
    }
}
