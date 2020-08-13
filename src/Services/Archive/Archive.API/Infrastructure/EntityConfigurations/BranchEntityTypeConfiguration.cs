using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archive.API.Infrastructure.EntityConfigurations
{
    using Model;

    public class BranchEntityTypeConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Branch");
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Parent)
            .WithMany(b => b.Children);

            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.ShortName).IsRequired();
        }
    }
}
