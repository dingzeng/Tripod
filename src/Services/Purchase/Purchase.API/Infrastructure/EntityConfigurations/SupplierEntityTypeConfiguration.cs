using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Purchase.API.Model;

namespace Purchase.API.Infrastructure.EntityConfigurations
{
	public class SupplierEntityTypeConfiguration : IEntityTypeConfiguration<Supplier>
	{
		public void Configure(EntityTypeBuilder<Supplier> builder)
		{
			builder.ToTable("Supplier");
			builder.HasKey(s => s.Id);

			builder.HasOne(s => s.Region).WithMany(sr => sr.Suppliers).HasForeignKey(s => s.RegionId);
		}
	}
}