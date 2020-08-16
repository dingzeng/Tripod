using Microsoft.EntityFrameworkCore.Migrations;

namespace Purchase.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupplierRegions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierRegions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RegionId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    SettlementMode = table.Column<int>(nullable: false),
                    SettleDays = table.Column<int>(nullable: true),
                    SettleDate = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ContactsName = table.Column<string>(nullable: true),
                    ContactsMobile = table.Column<string>(nullable: true),
                    ContactsTel = table.Column<string>(nullable: true),
                    ContactsEmail = table.Column<string>(nullable: true),
                    AccountBank = table.Column<string>(nullable: true),
                    AccountNo = table.Column<string>(nullable: true),
                    TaxRegistrationNo = table.Column<string>(nullable: true),
                    BusinessLicenseNo = table.Column<string>(nullable: true),
                    Memo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplier_SupplierRegions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "SupplierRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_RegionId",
                table: "Supplier",
                column: "RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "SupplierRegions");
        }
    }
}
