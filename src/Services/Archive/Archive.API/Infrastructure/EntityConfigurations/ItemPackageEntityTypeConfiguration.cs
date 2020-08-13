using System;
using Archive.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Archive.API.Infrastructure.EntityConfigurations
{
    public class ItemPackageEntityTypeConfiguration : IEntityTypeConfiguration<ItemPackage>
    {
        public void Configure(EntityTypeBuilder<ItemPackage> builder)
        {
            builder.ToTable("ItemPackage");
            builder.HasKey(i => i.Id);

            builder.HasOne(ip => ip.Item)
            .WithMany(i => i.Packages)
            .HasForeignKey(ip => ip.ItemId)
            .IsRequired();

            builder.Property(ip => ip.Barcode).IsRequired().HasMaxLength(20);
            builder.Property(ip => ip.UnitName).IsRequired().HasMaxLength(10);
            builder.Property(ip => ip.PurchasePrice).HasColumnType("nvarchar(18,4)");
            builder.Property(ip => ip.DeliveryPrice).HasColumnType("nvarchar(18,4)");
            builder.Property(ip => ip.SalesPrice).HasColumnType("nvarchar(18,4)");
            builder.Property(ip => ip.RetailPrice).HasColumnType("nvarchar(18,4)");
        }
    }
}