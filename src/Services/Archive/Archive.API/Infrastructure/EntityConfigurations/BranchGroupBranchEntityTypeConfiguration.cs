using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archive.API.Infrastructure.EntityConfigurations
{
    using Model;

    public class BranchGroupBranchEntityTypeConfiguration : IEntityTypeConfiguration<BranchGroupBranch>
    {
        public void Configure(EntityTypeBuilder<BranchGroupBranch> builder)
        {
            builder.ToTable("BranchGroupBranch");
            builder.HasKey(b => b.Id);

            builder.HasOne(bgb => bgb.Branch)
            .WithMany(b => b.BranchGroupBranches)
            .HasForeignKey(bgb => bgb.BranchId)
            .IsRequired();

            builder
            .HasOne(bgb => bgb.BranchGroup)
            .WithMany(bg => bg.BranchGroupBranches)
            .HasForeignKey(bgb => bgb.BranchGroupId)
            .IsRequired();
        }
    }
}
