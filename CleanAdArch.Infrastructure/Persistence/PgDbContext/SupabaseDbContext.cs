using System.Reflection;
using CleanAdArch.Domain.Models.Ads;
using CleanAdArch.Domain.Models.Category;
using CleanAdArch.Domain.Models.City;
using CleanAdArch.Domain.Models.EndpointLog;
using CleanAdArch.Domain.Models.RefreshToken;
using CleanAdArch.Domain.Models.SubCategory;
using CleanAdArch.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CleanAdArch.Infrastructure.Persistence.PgDbContext;

public class SupabaseDbContext : DbContext
{
    public SupabaseDbContext() : base()
    {
    }
    public SupabaseDbContext(DbContextOptions<SupabaseDbContext> options) : base(options)
    {
    }
    // dotnet ef --startup-project ..\CleanAdArch.API\CleanAdArch.API.csproj migrations add MyMigration --context SupabaseDbContext --output-dir Persistence/Migrations
  // dotnet ef database update -- project .\CleanAdArch.Infrastructure.csproj

    public DbSet<User?> Users { get; set; } = null!;
    public DbSet<SubCategory> SubCategories { get; set; } = null!;
    public DbSet<EndpointLog> EndpointLogs { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<Category?> Categories { get; set; } = null!;
    public DbSet<Ads> AdsEnumerable { get; set; } = null!;
    
    public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "../CleanAdArch.API/appsettings.json"))
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(),
                    $"../Api/appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json"),
                optional: true)
            // .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "../CleanAdArch.API/appsettings.json"))
            .Build();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

}