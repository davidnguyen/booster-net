using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Angelo.Booster.Inventory.Service.Products;

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

        builder.Property(x => x.Name)
            .IsRequired();
    }
}