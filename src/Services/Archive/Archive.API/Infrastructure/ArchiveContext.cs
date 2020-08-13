using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archive.API.Infrastructure
{
    using Model;
    using Infrastructure.EntityConfigurations;

    public class ArchiveContext : DbContext
    {
        public ArchiveContext(DbContextOptions<ArchiveContext> options) : base(options)
        {

        }

        public DbSet<BranchGroup> BranchGroups { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchStore> BranchStores { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemBarcode> ItemBarcodes { get; set; }
        public DbSet<ItemPackage> ItemPackages { get; set; }
        public DbSet<ItemPurchasePrice> ItemPurchasePrices { get; set; }
        public DbSet<ItemDeliveryPrice> ItemDeliveryPrices { get; set; }
        public DbSet<ItemSellingPrice> ItemSellingPrices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BranchEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BrandEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new ItemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ItemBarcodeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPackageEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPurchasePriceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ItemDeliveryPriceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ItemSellingPriceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BranchGroupEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BranchGroupBranchEntityTypeConfiguration());
        }
    }
}
