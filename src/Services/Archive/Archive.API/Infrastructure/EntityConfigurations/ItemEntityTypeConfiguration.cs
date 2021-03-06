using System;
using Archive.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Archive.API.Infrastructure.EntityConfigurations
{
    public class ItemEntityTypeConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");
            builder.HasKey(i => i.Id);

            builder.HasOne(i => i.Category1).WithMany().HasForeignKey(i => i.CategoryId1);
            builder.HasOne(i => i.Category2).WithMany().HasForeignKey(i => i.CategoryId2);
            builder.HasOne(i => i.Category3).WithMany().HasForeignKey(i => i.CategoryId3);

            builder.HasOne(i => i.Brand)
            .WithMany(b => b.Items)
            .HasForeignKey(i => i.BrandId)
            .IsRequired();

            builder.HasOne(i => i.Department)
            .WithMany(d => d.Items)
            .HasForeignKey(i => i.DepartmentId)
            .IsRequired();

            builder.Property(i => i.Barcode).IsRequired();
            builder.Property(i => i.Name).IsRequired();
            builder.Property(i => i.ShortName).IsRequired();
            builder.Property(i => i.UnitName).IsRequired();
            builder.Property(i => i.SupplierId).HasMaxLength(10).IsRequired();
            builder.Property(i => i.SupplierName).IsRequired();

            builder.Property(i => i.RetailPrice).HasColumnType("decimal(18,4)");
            builder.Property(i => i.PurchasePrice).HasColumnType("decimal(18,4)");
            builder.Property(i => i.SalesPrice).HasColumnType("decimal(18,4)");
            builder.Property(i => i.DeliveryPrice).HasColumnType("decimal(18,4)");

            builder.Property(i => i.ReferProfitRate).HasColumnType("decimal(18,4)");
            builder.Property(i => i.PurchaseTaxRate).HasColumnType("decimal(18,4)");
            builder.Property(i => i.SalesTaxRate).HasColumnType("decimal(18,4)");
        }
    }
}