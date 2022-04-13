using Angelo.Booster.Inventory.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var logger = LoggerFactory.Create(config =>
    {
        config.AddConsole();
        config.AddConfiguration(builder.Configuration.GetSection("Logging"));
    }).CreateLogger("Program");

// Add services to the container.
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    SeedData.EnsureSeedData(app);
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
