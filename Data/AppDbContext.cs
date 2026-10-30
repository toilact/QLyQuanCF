using Microsoft.EntityFrameworkCore;
using CoffeeShopManagement.Models;

namespace CoffeeShopManagement.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Table> Tables => Set<Table>();
    public DbSet<Bill> Bills => Set<Bill>();
    public DbSet<BillDetail> BillDetails => Set<BillDetail>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User unique index
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

        // Decimal precisions
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Bill>()
            .Property(b => b.TotalAmount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<BillDetail>()
            .Property(bd => bd.UnitPrice)
            .HasPrecision(18, 2);

        // Relationships & Delete Behaviors
        modelBuilder.Entity<Bill>()
            .HasOne(b => b.Table)
            .WithMany(t => t.Bills)
            .HasForeignKey(b => b.TableId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Bill>()
            .HasOne(b => b.User)
            .WithMany(u => u.Bills)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BillDetail>()
            .HasOne(bd => bd.Bill)
            .WithMany(b => b.Details)
            .HasForeignKey(bd => bd.BillId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BillDetail>()
            .HasOne(bd => bd.Product)
            .WithMany(p => p.BillDetails)
            .HasForeignKey(bd => bd.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

