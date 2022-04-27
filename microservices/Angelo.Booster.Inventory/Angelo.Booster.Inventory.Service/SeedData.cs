using Microsoft.EntityFrameworkCore;
using Serilog;
using Angelo.Booster.Libraries.Common.DataSeeding;
using Angelo.Booster.Inventory.Service.Common.Entities;

namespace Angelo.Booster.Inventory.Service;

public class SeedData
{
    public static void EnsureSeedData(WebApplication app)
    {
        using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            using var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
            dbContext!.Database.Migrate();
            EnsureSeedData(dbContext);
        }
    }

    private static void EnsureSeedData(ApplicationDbContext dbContext)
    {
        dbContext.LoadSeedData<Product>();
        dbContext.LoadSeedData<Category>(customEntityMapper: (record) => new Category {
            Id = new Guid(record.Id),
            Name = record.Name,
            ParentId = !string.IsNullOrEmpty(record.ParentId) 
                ? new Guid(record.ParentId) : null,
            UrlSlug = record.UrlSlug
        });
    }
}
