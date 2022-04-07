using Microsoft.AspNetCore.Mvc;
using Angelo.Booster.Inventory.Service.Common.Entities;

namespace Angelo.Booster.Inventory.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public ProductsController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IEnumerable<Product> Get()
    {
        return _dbContext.Products.ToArray();
    }
}
