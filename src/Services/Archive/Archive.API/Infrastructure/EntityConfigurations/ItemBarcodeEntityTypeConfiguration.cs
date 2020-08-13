using System;
using Archive.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Archive.API.Infrastructure.EntityConfigurations
{
    public class ItemBarcodeEntityTypeConfiguration : IEntityTypeConfiguration<ItemBarcode>
    {
        public void Configure(EntityTypeBuilder<ItemBarcode> builder)
        {
            builder.ToTable("ItemBarcode");
            builder.HasKey(i => i.Id);

            builder.HasOne(ib => ib.Item)
            .WithMany(i => i.Barcodes)
            .HasForeignKey(ib => ib.ItemId)
            .IsRequired();

            builder.Property(ib => ib.Barcode).IsRequired().HasMaxLength(20);
        }
    }
}