﻿using Archive.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archive.API.Infrastructure.EntityConfigurations
{
    public class BranchStoreEntityTypeConfiguration : IEntityTypeConfiguration<BranchStore>
    {
        public void Configure(EntityTypeBuilder<BranchStore> builder)
        {
            builder.ToTable("BranchStore");
            builder.HasKey(bs => bs.Id);

            builder.HasOne(s => s.Branch)
            .WithMany(b => b.Stores)
            .HasForeignKey(s => s.BranchId)
            .IsRequired();

            builder.Property(s => s.Name).IsRequired();
        }
    }
}
