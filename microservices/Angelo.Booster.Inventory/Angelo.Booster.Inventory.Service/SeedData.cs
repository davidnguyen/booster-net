using Microsoft.EntityFrameworkCore;
using Serilog;

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
        if (!dbContext.Products.Any())
        {
            Log.Debug("Products being populated");
            dbContext.Products.Add(new Common.Entities.Product(){
                Id = new Guid("00000000-0000-0000-0001-000000000000"),
                Name = "Tomato Truss 1KG Box"
            });
            dbContext.Products.Add(new Common.Entities.Product(){
                Id = new Guid("00000000-0000-0000-0001-000000000001"),
                Name = "Baby Spinach 300gr Package"
            });
            dbContext.SaveChanges();
        }
        else
        {
            Log.Debug("Products already populated");
        }
    }
}
