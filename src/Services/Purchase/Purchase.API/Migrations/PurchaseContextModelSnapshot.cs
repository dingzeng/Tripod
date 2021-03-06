﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Purchase.API.Infrastructure;

namespace Purchase.API.Migrations
{
    [DbContext(typeof(PurchaseContext))]
    partial class PurchaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Purchase.API.Model.Supplier", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountBank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessLicenseNo")
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("SettleDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SettleDays")
                        .HasColumnType("int");

                    b.Property<int>("SettlementMode")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TaxRegistrationNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("Purchase.API.Model.SupplierRegion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SupplierRegions");
                });

            modelBuilder.Entity("Purchase.API.Model.Supplier", b =>
                {
                    b.HasOne("Purchase.API.Model.SupplierRegion", "Region")
                        .WithMany("Suppliers")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
