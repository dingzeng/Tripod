using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Archive.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreateOperId = table.Column<long>(nullable: false),
                    CreateOperName = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastUpdateOperId = table.Column<long>(nullable: false),
                    LastUpdateOperName = table.Column<string>(nullable: true),
                    LastUpdateTime = table.Column<DateTime>(nullable: false),
                    ParentId = table.Column<string>(nullable: true),
                    ParentName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    ContactsName = table.Column<string>(nullable: true),
                    ContactsMobile = table.Column<string>(nullable: true),
                    ContactsTel = table.Column<string>(nullable: true),
                    ContactsEmail = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    GiftStoreId = table.Column<int>(nullable: true),
                    ReturnStoreId = table.Column<int>(nullable: true),
                    PurchaseStoreId = table.Column<int>(nullable: true),
                    Memo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchStores",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IsUsable = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchStores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "BranchStores");
        }
    }
}
