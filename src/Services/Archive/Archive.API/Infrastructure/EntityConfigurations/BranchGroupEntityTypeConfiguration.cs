using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archive.API.Infrastructure.EntityConfigurations
{
    using Model;

    public class BranchGroupEntityTypeConfiguration : IEntityTypeConfiguration<BranchGroup>
    {
        public void Configure(EntityTypeBuilder<BranchGroup> builder)
        {
            builder.ToTable("BranchGroup");
            builder.HasKey(b => b.Id);

            builder.Property(bg => bg.Name).IsRequired();
        }
    }
}
