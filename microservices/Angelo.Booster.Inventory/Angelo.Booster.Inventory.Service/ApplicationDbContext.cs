using Microsoft.EntityFrameworkCore;
using Angelo.Booster.Inventory.Service.Products;
using Angelo.Booster.Inventory.Service.Categories;

namespace Angelo.Booster.Inventory.Service;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
            : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging(true);
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Product> Products => Set<Product>();

    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new ProductBuilder(this).Configure(modelBuilder.Entity<Product>());
        new CategoryBuilder(this).Configure(modelBuilder.Entity<Category>());
    }
}