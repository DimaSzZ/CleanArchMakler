using CleanAdArch.Domain.Interface.Accessors;
using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Interface.Storages;
using CleanAdArch.Domain.Interface.Utils.Logger;
using CleanAdArch.Domain.Interface.Utils.PasswordHasher;
using CleanAdArch.Domain.Interface.Utils.Tokens;
using CleanAdArch.Domain.Settings.Storages;
using CleanAdArch.Domain.Settings.Utils.File;
using CleanAdArch.Domain.Settings.Utils.HashingSettings;
using CleanAdArch.Infrastructure.Accessors;
using CleanAdArch.Infrastructure.Persistence.PgDbContext;
using CleanAdArch.Infrastructure.Repositories;
using CleanAdArch.Infrastructure.Storages;
using CleanAdArch.Infrastructure.Utils.File;
using CleanAdArch.Infrastructure.Utils.Logger;
using CleanAdArch.Infrastructure.Utils.PasswordHasher;
using CleanAdArch.Infrastructure.Utils.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Supabase;


namespace CleanAdArch.Infrastructure.DepInj;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddUtils();
        services.AddRepositories();
        services.AddStorages(configuration);
        services.AddIOptions(configuration);
        services.AddDb(configuration);
        
        return services;
    }

    private static IServiceCollection AddUtils(
        this IServiceCollection services)
    {
        services.AddScoped<ITokenGenerator, TokenGenerator>();
        services.AddScoped<IAccessTokenService, AccessTokenService>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        services.AddScoped<IAuthenticateService, AuthenticateService>();
        services.AddScoped<IFileUtils, FileUtils>();
        services.AddScoped<ILogger, Logger>();
        services.AddScoped<IPasswordHasher,PasswordHasher>();
        services.AddScoped<IUserAccessor, UserAccessor>();
        return services;
    }

    private static IServiceCollection AddStorages(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var settings = new SupabaseSettings();
        configuration.Bind(nameof(SupabaseSettings), settings);
        services.AddSingleton(settings);
        services.AddSingleton<ISupabaseStorage, SupabaseStorage>();
        return services;
    }

    private static IServiceCollection AddDb(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<SupabaseDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }

    private static IServiceCollection AddRepositories(
    this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<ISubCategoryRepository, SubCategory>();
        services.AddScoped<IEndpointLogRepository,EndpointLogRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IAdsRepository, AdsRepository>();
        services.AddScoped<ISearchRepository, SearchRepository>();
        return services;
    }
    private static IServiceCollection AddIOptions(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.Configure<HashingSettings>(configuration.GetSection(nameof(HashingSettings)));
        return services;
    }
}