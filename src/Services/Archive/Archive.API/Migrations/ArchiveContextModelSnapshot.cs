﻿// <auto-generated />
using System;
using Archive.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Archive.API.Migrations
{
    [DbContext(typeof(ArchiveContext))]
    partial class ArchiveContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Archive.API.Model.Branch", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactsEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactsMobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactsName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactsTel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Memo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Branch");
                });

            modelBuilder.Entity("Archive.API.Model.BranchGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreateOperId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BranchGroup");
                });

            modelBuilder.Entity("Archive.API.Model.BranchGroupBranch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchGroupId")
                        .HasColumnType("int");

                    b.Property<string>("BranchId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BranchGroupId");

                    b.HasIndex("BranchId");

                    b.ToTable("BranchGroupBranch");
                });

            modelBuilder.Entity("Archive.API.Model.BranchStore", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BranchId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDefaultGiftStoreId")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDefaultPurchaseStore")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDefaultReturnStore")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUsable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("BranchStores");
                });

            modelBuilder.Entity("Archive.API.Model.Brand", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Archive.API.Model.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Archive.API.Model.Department", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("Archive.API.Model.Item", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId2")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId3")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("DeliveryPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("DepartmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("LeastDeliveryQty")
                        .HasColumnType("int");

                    b.Property<string>("Memo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductionPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PurchasePrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal?>("PurchaseTaxRate")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int?>("QualityDays")
                        .HasColumnType("int");

                    b.Property<decimal?>("ReferProfitRate")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("RetailPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal?>("SalesPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal?>("SalesTaxRate")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("SupplierId")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransportMode")
                        .HasColumnType("int");

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WarningDays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId1");

                    b.HasIndex("CategoryId2");

                    b.HasIndex("CategoryId3");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Archive.API.Model.ItemBarcode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Memo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemBarcode");
                });

            modelBuilder.Entity("Archive.API.Model.ItemDeliveryPrice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BranchId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("DeliveryPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Memo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemDeliveryPrice");
                });

            modelBuilder.Entity("Archive.API.Model.ItemPackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<decimal?>("DeliveryPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("FactorQty")
                        .HasColumnType("int");

                    b.Property<bool>("IsDefaultDeliveryUnit")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDefaultPurchaseUnit")
                        .HasColumnType("bit");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Memo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PurchasePrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("RetailPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal?>("SalesPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemPackage");
                });

            modelBuilder.Entity("Archive.API.Model.ItemPurchasePrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("BranchId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FactorQty")
                        .HasColumnType("int");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("bit");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Memo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("SupplierId")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemPurchasePrice");
                });

            modelBuilder.Entity("Archive.API.Model.ItemSellingPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("BranchId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FactorQty")
                        .HasColumnType("int");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Memo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RetailPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("SalesPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemSellingPrice");
                });

            modelBuilder.Entity("Archive.API.Model.Branch", b =>
                {
                    b.HasOne("Archive.API.Model.Branch", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Archive.API.Model.BranchGroupBranch", b =>
                {
                    b.HasOne("Archive.API.Model.BranchGroup", "BranchGroup")
                        .WithMany("BranchGroupBranches")
                        .HasForeignKey("BranchGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Archive.API.Model.Branch", "Branch")
                        .WithMany("BranchGroupBranches")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Archive.API.Model.BranchStore", b =>
                {
                    b.HasOne("Archive.API.Model.Branch", "Branch")
                        .WithMany("Stores")
                        .HasForeignKey("BranchId");
                });

            modelBuilder.Entity("Archive.API.Model.Category", b =>
                {
                    b.HasOne("Archive.API.Model.Category", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Archive.API.Model.Item", b =>
                {
                    b.HasOne("Archive.API.Model.Brand", "Brand")
                        .WithMany("Items")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Archive.API.Model.Category", "Category1")
                        .WithMany()
                        .HasForeignKey("CategoryId1");

                    b.HasOne("Archive.API.Model.Category", "Category2")
                        .WithMany()
                        .HasForeignKey("CategoryId2");

                    b.HasOne("Archive.API.Model.Category", "Category3")
                        .WithMany()
                        .HasForeignKey("CategoryId3");

                    b.HasOne("Archive.API.Model.Department", "Department")
                        .WithMany("Items")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Archive.API.Model.ItemBarcode", b =>
                {
                    b.HasOne("Archive.API.Model.Item", "Item")
                        .WithMany("Barcodes")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Archive.API.Model.ItemDeliveryPrice", b =>
                {
                    b.HasOne("Archive.API.Model.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Archive.API.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Archive.API.Model.ItemPackage", b =>
                {
                    b.HasOne("Archive.API.Model.Item", "Item")
                        .WithMany("Packages")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Archive.API.Model.ItemPurchasePrice", b =>
                {
                    b.HasOne("Archive.API.Model.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Archive.API.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Archive.API.Model.ItemSellingPrice", b =>
                {
                    b.HasOne("Archive.API.Model.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Archive.API.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
