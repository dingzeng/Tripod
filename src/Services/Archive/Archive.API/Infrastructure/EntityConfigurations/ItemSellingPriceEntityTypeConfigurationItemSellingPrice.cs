using System;
using Archive.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Archive.API.Infrastructure.EntityConfigurations
{
    public class ItemSellingPriceEntityTypeConfiguration : IEntityTypeConfiguration<ItemSellingPrice>
    {
        public void Configure(EntityTypeBuilder<ItemSellingPrice> builder)
        {
            builder.ToTable("ItemSellingPrice");
            builder.HasKey(i => i.Id);

            builder.HasOne(isp => isp.Item);
            
            builder.Property(isp => isp.ItemId).IsRequired();
            builder.Property(isp => isp.Barcode).IsRequired().HasMaxLength(20);
            builder.Property(isp => isp.BranchId).IsRequired();
            builder.Property(isp => isp.UnitName).IsRequired().HasMaxLength(10);

            builder.Property(isp => isp.RetailPrice).HasColumnType("decimal(18,4)");
            builder.Property(isp => isp.SalesPrice).HasColumnType("decimal(18,4)");
        }
    }
}