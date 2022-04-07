using Angelo.Booster.Inventory.Service.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Angelo.Booster.Inventory.Service.Common.Builders;

public class ProductBuilder : IEntityTypeConfiguration<Product>
{
    private readonly ApplicationDbContext _dbContext;

    public ProductBuilder(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
    }
}