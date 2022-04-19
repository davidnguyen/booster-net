using Angelo.Booster.Inventory.Service.Common.Entities;

namespace Angelo.Booster.Inventory.Service.Queries;

public class ProductQuery
{
    public IEnumerable<Product> GetProducts(ApplicationDbContext dbContext)
    {
        return dbContext.Products.ToArray();
    }

    public Product GetProduct(ApplicationDbContext dbContext, string productId)
    {
        var product = dbContext.Products.SingleOrDefault(x => x.Id == new Guid(productId));

        if (product == null)
        {
            throw new Exception("productId does not exist");
        }

        return product;
    }
}