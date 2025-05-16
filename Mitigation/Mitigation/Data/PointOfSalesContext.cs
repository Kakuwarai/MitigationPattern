using Microsoft.EntityFrameworkCore;
using Mitigation.Models;

public class PointOfSalesContext : DbContext
{
    public PointOfSalesContext(DbContextOptions<PointOfSalesContext> options) : base(options) { }

    public DbSet<StoreItem> Candidates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<StoreItem>()
            .Property(c => c.Id)
            .IsRequired();

        modelBuilder.Entity<StoreItem>()
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<StoreItem>()
            .Property(c => c.Barcode)
            .IsRequired()
            .HasMaxLength(150);

        modelBuilder.Entity<StoreItem>()
          .Property(c => c.Price)
          .IsRequired();

        modelBuilder.Entity<Sales>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.SalesNumber)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(e => e.StoreItemId)
                  .IsRequired();

            entity.HasOne(s => s.StoreItem)
                  .WithMany()
                  .HasForeignKey(s => s.StoreItemId)
                  .OnDelete(DeleteBehavior.Cascade);
        });


        modelBuilder.Entity<VSales>()
            .ToView("VPayroll", "PointOfSales")
            .HasNoKey();
    }
}
