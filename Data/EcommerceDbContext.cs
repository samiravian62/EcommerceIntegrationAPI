using Microsoft.EntityFrameworkCore;
using EcommerceIntegrationAPI.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EcommerceIntegrationAPI.Data
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;

        public DbSet<EcommerceOrder> EcommerceOrders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(i => i.Order!)
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

            // Map to existing table
            modelBuilder.Entity<EcommerceOrder>().ToTable("EcommerceOrders");

            // Optional: enforce column mappings (if names match, not strictly required)
            modelBuilder.Entity<EcommerceOrder>().Property(e => e.Platform).IsRequired();
            modelBuilder.Entity<EcommerceOrder>().Property(e => e.PlatformOrderId).IsRequired();
            modelBuilder.Entity<EcommerceOrder>().Property(e => e.CreatedAt).IsRequired();
        }


    }
}
