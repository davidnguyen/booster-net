namespace Angelo.Booster.Inventory.Service.Common.Entities;

public class CategoryCore
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid? ParentId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string UrlSlug { get; set; } = string.Empty;
} 

public class Category : CategoryCore
{
    public Category? Parent { get; set; } = null;

    public List<Category> Children { get; set; } = new List<Category>();
}