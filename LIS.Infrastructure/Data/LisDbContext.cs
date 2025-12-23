using Microsoft.EntityFrameworkCore;
using LIS.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace LIS.Infrastructure.Data
{
    public class LisDbContext : DbContext
    {
        public LisDbContext(DbContextOptions<LisDbContext> options)
            : base(options)
        {
        }
        public DbSet<LabOrder> LabOrders => Set<LabOrder>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LabOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.Status)
                      .HasConversion<string>()
                      .IsRequired();

                entity.Property(e => e.OrderedAt)
                      .IsRequired();
            });

            modelBuilder.Entity<LabOrderLog>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Action)
                      .IsRequired();

                entity.Property(e => e.PerformedBy)
                      .IsRequired();

                entity.Property(e => e.PerformedAt)
                      .IsRequired();

                entity.HasOne(e => e.LabOrder)
                      .WithMany()
                      .HasForeignKey(e => e.LabOrderId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

        }

        public DbSet<LabOrderLog> LabOrderLogs => Set<LabOrderLog>();

    }
}
