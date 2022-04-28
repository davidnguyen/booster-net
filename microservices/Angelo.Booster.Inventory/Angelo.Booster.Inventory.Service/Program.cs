using Angelo.Booster.Inventory.Service;
using Angelo.Booster.Inventory.Service.Products;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(ctx.Configuration));

var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();

services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options => {
        options.Authority = builder.Configuration["App:IdentityServer"];
        options.TokenValidationParameters.ValidateAudience = false;
        options.TokenValidationParameters.ValidateIssuer = false;
        options.RequireHttpsMetadata = false;
    });

services.AddAuthorization(options => 
    options.AddPolicy("ApiScope", policy => {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "inventoryApi");
    })
);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

services.AddGraphQLServer()
    .RegisterDbContext<ApplicationDbContext>(DbContextKind.Resolver)
    .AddQueryType<ProductQuery>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    SeedData.EnsureSeedData(app);
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapGraphQL();

app.Run();
