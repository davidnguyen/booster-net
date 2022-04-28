
namespace Angelo.Booster.Inventory.Service.Products;

public class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;
}