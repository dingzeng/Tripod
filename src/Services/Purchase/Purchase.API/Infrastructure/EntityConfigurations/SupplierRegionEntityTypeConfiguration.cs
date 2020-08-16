using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Purchase.API.Model;

namespace Purchase.API.Infrastructure.EntityConfigurations
{
	public class SupplierRegionEntityTypeConfiguration : IEntityTypeConfiguration<Supplier>
	{
		public void Configure(EntityTypeBuilder<Supplier> builder)
		{
			builder.ToTable("SupplierRegion");
			builder.HasKey(s => s.Id);
		}
	}
}