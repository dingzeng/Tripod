using System;
using Archive.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Archive.API.Infrastructure.EntityConfigurations
{
    public class ItemPurchasePriceEntityTypeConfiguration : IEntityTypeConfiguration<ItemPurchasePrice>
    {
        public void Configure(EntityTypeBuilder<ItemPurchasePrice> builder)
        {
            builder.ToTable("ItemPurchasePrice");
            builder.HasKey(i => i.Id);

            builder.HasOne(ipp => ipp.Item);
            builder.HasOne(ipp => ipp.Branch);

            builder.Property(ipp => ipp.ItemId).IsRequired();
            builder.Property(ipp => ipp.Barcode).IsRequired().HasMaxLength(20);
            builder.Property(ipp => ipp.BranchId).IsRequired();
            builder.Property(ipp => ipp.SupplierId).IsRequired().HasMaxLength(10);
            builder.Property(ipp => ipp.SupplierName).IsRequired().HasMaxLength(20);
            builder.Property(ipp => ipp.UnitName).IsRequired().HasMaxLength(10);
            builder.Property(ipp => ipp.PurchasePrice).HasColumnType("decimal(18,4)");
        }
    }
}