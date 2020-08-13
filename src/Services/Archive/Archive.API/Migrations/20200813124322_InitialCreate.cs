using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Archive.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BranchGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateOperId = table.Column<long>(nullable: false),
                    CreateOperName = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastUpdateOperId = table.Column<long>(nullable: false),
                    LastUpdateOperName = table.Column<string>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    IsPrivate = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreateOperId = table.Column<long>(nullable: false),
                    CreateOperName = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastUpdateOperId = table.Column<long>(nullable: false),
                    LastUpdateOperName = table.Column<string>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: false),
                    ParentId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ShortName = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    ContactsName = table.Column<string>(nullable: true),
                    ContactsMobile = table.Column<string>(nullable: true),
                    ContactsTel = table.Column<string>(nullable: true),
                    ContactsEmail = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Memo = table.Column<string>(nullable: true),
                    BranchGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branch_BranchGroup_BranchGroupId",
                        column: x => x.BranchGroupId,
                        principalTable: "BranchGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branch_Branch_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Barcode = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ShortName = table.Column<string>(nullable: false),
                    CategoryId = table.Column<string>(nullable: false),
                    BrandId = table.Column<string>(nullable: false),
                    DepartmentId = table.Column<string>(nullable: false),
                    UnitName = table.Column<string>(nullable: false),
                    PrimarySupplierId = table.Column<string>(maxLength: 10, nullable: false),
                    PrimarySupplierName = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    RetailPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    SalesPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    DeliveryPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    ReferProfitRate = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Size = table.Column<string>(nullable: true),
                    TransportMode = table.Column<int>(nullable: false),
                    QualityDays = table.Column<int>(nullable: true),
                    WarningDays = table.Column<int>(nullable: true),
                    LeastDeliveryQty = table.Column<int>(nullable: true),
                    ProductionPlace = table.Column<string>(nullable: true),
                    PurchaseTaxRate = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    SalesTaxRate = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchGroupBranch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchGroupId = table.Column<int>(nullable: false),
                    BranchId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchGroupBranch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchGroupBranch_BranchGroup_BranchGroupId",
                        column: x => x.BranchGroupId,
                        principalTable: "BranchGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchGroupBranch_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchStores",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IsUsable = table.Column<bool>(nullable: false),
                    IsDefaultGiftStoreId = table.Column<bool>(nullable: false),
                    IsDefaultReturnStore = table.Column<bool>(nullable: false),
                    IsDefaultPurchaseStore = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchStores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchStores_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemBarcode",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<string>(nullable: false),
                    Barcode = table.Column<string>(maxLength: 20, nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemDeliveryPrice",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<string>(nullable: false),
                    BranchId = table.Column<string>(nullable: false),
                    DeliveryPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemDeliveryPrice_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemPackage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<string>(nullable: false),
                    Barcode = table.Column<string>(maxLength: 20, nullable: false),
                    UnitName = table.Column<string>(maxLength: 10, nullable: false),
                    FactorQty = table.Column<int>(nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    DeliveryPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    SalesPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    RetailPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemPurchasePrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<string>(nullable: false),
                    Barcode = table.Column<string>(maxLength: 20, nullable: false),
                    BranchId = table.Column<string>(nullable: false),
                    SupplierId = table.Column<string>(maxLength: 10, nullable: false),
                    SupplierName = table.Column<string>(maxLength: 20, nullable: false),
                    IsPrimary = table.Column<bool>(nullable: false),
                    UnitName = table.Column<string>(maxLength: 10, nullable: false),
                    FactorQty = table.Column<int>(nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPurchasePrice_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemSellingPrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<string>(nullable: false),
                    Barcode = table.Column<string>(maxLength: 20, nullable: false),
                    BranchId = table.Column<string>(nullable: false),
                    UnitName = table.Column<string>(maxLength: 10, nullable: false),
                    FactorQty = table.Column<int>(nullable: false),
                    RetailPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    SalesPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemSellingPrice_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_BranchGroupId",
                table: "Branch",
                column: "BranchGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_ParentId",
                table: "Branch",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchGroupBranch_BranchGroupId",
                table: "BranchGroupBranch",
                column: "BranchGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchGroupBranch_BranchId",
                table: "BranchGroupBranch",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchStores_BranchId",
                table: "BranchStores",
                column: "BranchId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchGroupBranch");

            migrationBuilder.DropTable(
                name: "BranchStores");

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
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "BranchGroup");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
