using Microsoft.EntityFrameworkCore.Migrations;

namespace Archive.API.Migrations
{
    public partial class AddItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiftStoreId",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "ParentName",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "PurchaseStoreId",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "ReturnStoreId",
                table: "Branch");

            migrationBuilder.AlterColumn<bool>(
                name: "IsUsable",
                table: "BranchStores",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BranchId",
                table: "BranchStores",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefaultGiftStoreId",
                table: "BranchStores",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefaultPurchaseStore",
                table: "BranchStores",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefaultReturnStore",
                table: "BranchStores",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "ParentId",
                table: "Branch",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Barcode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    CategoryId = table.Column<string>(nullable: true),
                    BrandId = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<string>(nullable: true),
                    UnitName = table.Column<string>(nullable: true),
                    PrimarySupplierId = table.Column<string>(nullable: true),
                    PrimarySupplierName = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    RetailPrice = table.Column<decimal>(nullable: false),
                    PurchasePrice = table.Column<decimal>(nullable: false),
                    SalesPrice = table.Column<decimal>(nullable: false),
                    DeliveryPrice = table.Column<decimal>(nullable: false),
                    ReferProfitRate = table.Column<decimal>(nullable: false),
                    Size = table.Column<string>(nullable: true),
                    TransportMode = table.Column<int>(nullable: false),
                    QualityDays = table.Column<int>(nullable: true),
                    WarningDays = table.Column<int>(nullable: true),
                    LeastDeliveryQty = table.Column<int>(nullable: true),
                    ProductionPlace = table.Column<string>(nullable: true),
                    PurchaseTaxRate = table.Column<decimal>(nullable: true),
                    SalesTaxRate = table.Column<decimal>(nullable: true),
                    Memo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemBarcode",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<string>(nullable: true),
                    Barcode = table.Column<string>(nullable: true),
                    Memo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBarcode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemBarcode_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemDeliveryPrice",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    DeliveryPrice = table.Column<decimal>(nullable: false),
                    Memo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDeliveryPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemDeliveryPrice_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemDeliveryPrice_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemPackage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<string>(nullable: true),
                    Barcode = table.Column<string>(nullable: true),
                    UnitName = table.Column<string>(nullable: true),
                    FactorQty = table.Column<int>(nullable: false),
                    RetailPrice = table.Column<decimal>(nullable: false),
                    SalesPrice = table.Column<decimal>(nullable: false),
                    PurchasePrice = table.Column<decimal>(nullable: false),
                    IsDefaultPurchaseUnit = table.Column<bool>(nullable: false),
                    IsDefaultDeliveryUnit = table.Column<bool>(nullable: false),
                    Memo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPackage_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemPurchasePrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<string>(nullable: true),
                    Barcode = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    SupplierId = table.Column<string>(nullable: true),
                    SupplierName = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false),
                    UnitName = table.Column<string>(nullable: true),
                    FactorQty = table.Column<int>(nullable: false),
                    PurchasePrice = table.Column<decimal>(nullable: false),
                    Memo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPurchasePrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPurchasePrice_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemPurchasePrice_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemSellingPrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<string>(nullable: true),
                    Barcode = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    UnitName = table.Column<string>(nullable: true),
                    FactorQty = table.Column<int>(nullable: false),
                    RetailPrice = table.Column<decimal>(nullable: false),
                    SalesPrice = table.Column<decimal>(nullable: false),
                    Memo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSellingPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemSellingPrice_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemSellingPrice_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchStores_BranchId",
                table: "BranchStores",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_ParentId",
                table: "Branch",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_BrandId",
                table: "Item",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CategoryId",
                table: "Item",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_DepartmentId",
                table: "Item",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBarcode_ItemId",
                table: "ItemBarcode",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDeliveryPrice_BranchId",
                table: "ItemDeliveryPrice",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDeliveryPrice_ItemId",
                table: "ItemDeliveryPrice",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPackage_ItemId",
                table: "ItemPackage",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPurchasePrice_BranchId",
                table: "ItemPurchasePrice",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPurchasePrice_ItemId",
                table: "ItemPurchasePrice",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSellingPrice_BranchId",
                table: "ItemSellingPrice",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSellingPrice_ItemId",
                table: "ItemSellingPrice",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Branch_ParentId",
                table: "Branch",
                column: "ParentId",
                principalTable: "Branch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchStores_Branch_BranchId",
                table: "BranchStores",
                column: "BranchId",
                principalTable: "Branch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Branch_ParentId",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchStores_Branch_BranchId",
                table: "BranchStores");

            migrationBuilder.DropTable(
                name: "ItemBarcode");

            migrationBuilder.DropTable(
                name: "ItemDeliveryPrice");

            migrationBuilder.DropTable(
                name: "ItemPackage");

            migrationBuilder.DropTable(
                name: "ItemPurchasePrice");

            migrationBuilder.DropTable(
                name: "ItemSellingPrice");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropIndex(
                name: "IX_BranchStores_BranchId",
                table: "BranchStores");

            migrationBuilder.DropIndex(
                name: "IX_Branch_ParentId",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "IsDefaultGiftStoreId",
                table: "BranchStores");

            migrationBuilder.DropColumn(
                name: "IsDefaultPurchaseStore",
                table: "BranchStores");

            migrationBuilder.DropColumn(
                name: "IsDefaultReturnStore",
                table: "BranchStores");

            migrationBuilder.AlterColumn<int>(
                name: "IsUsable",
                table: "BranchStores",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "BranchId",
                table: "BranchStores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ParentId",
                table: "Branch",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GiftStoreId",
                table: "Branch",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParentName",
                table: "Branch",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseStoreId",
                table: "Branch",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReturnStoreId",
                table: "Branch",
                type: "int",
                nullable: true);
        }
    }
}
