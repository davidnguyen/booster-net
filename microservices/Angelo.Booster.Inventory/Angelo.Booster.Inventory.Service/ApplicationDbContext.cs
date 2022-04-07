using Microsoft.EntityFrameworkCore;
using Angelo.Booster.Inventory.Service.Common.Entities;
using Angelo.Booster.Inventory.Service.Common.Builders;

namespace Angelo.Booster.Inventory.Service;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions options)
            : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new ProductBuilder(this).Configure(modelBuilder.Entity<Product>());
    }
}