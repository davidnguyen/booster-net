using Microsoft.AspNetCore.Mvc;
using Angelo.Booster.Inventory.Service.Common.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Angelo.Booster.Inventory.Service.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
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
