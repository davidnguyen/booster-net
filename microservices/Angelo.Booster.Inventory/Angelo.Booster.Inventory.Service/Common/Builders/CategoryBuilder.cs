using Angelo.Booster.Inventory.Service.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Angelo.Booster.Inventory.Service.Common.Builders;

public class CategoryBuilder : IEntityTypeConfiguration<Category>
{
    private readonly ApplicationDbContext _dbContext;

    public CategoryBuilder(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.UrlSlug)
            .IsRequired();

        builder.HasOne(x => x.Parent)
            .WithMany(x => x.Children)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    }
}