namespace Angelo.Booster.Inventory.Service.Products;

public class ProductQuery
{
    /// <summary>
    /// Gets products by category
    /// </summary>
    /// <param name="dbContext">Database context</param>
    /// <param name="category">Category to fetch products for</param>
    /// <returns>Products</returns>
    public IEnumerable<Product> GetProducts(ApplicationDbContext dbContext, string category)
    {
        return dbContext.Products.ToArray();
    }

    /// <summary>
    /// Gets product details by productId
    /// </summary>
    /// <param name="dbContext">Database context</param>
    /// <param name="productId">Product identifier</param>
    /// <returns>Product</returns>
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