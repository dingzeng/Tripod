using System;
using Archive.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Archive.API.Infrastructure.EntityConfigurations
{
    public class ItemDeliveryPriceEntityTypeConfiguration : IEntityTypeConfiguration<ItemDeliveryPrice>
    {
        public void Configure(EntityTypeBuilder<ItemDeliveryPrice> builder)
        {
            builder.ToTable("ItemDeliveryPrice");
            builder.HasKey(i => i.Id);

            builder.HasOne(idp => idp.Item);

            builder.Property(idp => idp.ItemId).IsRequired();
            builder.Property(idp => idp.BranchId).IsRequired();
            builder.Property(idp => idp.DeliveryPrice).HasColumnType("decimal(18,4)");
        }
    }
}