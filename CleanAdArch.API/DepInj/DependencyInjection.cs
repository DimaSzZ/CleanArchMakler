using System.Reflection;
using System.Text;
using CleanAdArch.API.Filters;
using CleanAdArch.API.Swagger;
using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Settings.Utils.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace CleanAdArch.API.DepInj;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuth(configuration);
        services.AddControllersWithConfig();
        services.AddSwagger();
        return services;
    }
    private static IServiceCollection AddSwagger(
        this IServiceCollection services
    )
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo {Title = "InstagramCloneApi", Version = "v1.0.0"});
            options.SupportNonNullableReferenceTypes();
            options.OperationFilter<SwaggerAuthorizationFilter>();
            options.SchemaFilter<RequiredNotNullableSchemaFilter>();
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Scheme = "Bearer",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
              Enter 'Bearer' [space] and then your token in the text input below.
              \r\n\r\nExample: 'Bearer FuckingKeyY'"
            });
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
        return services;
    }
     private static IServiceCollection AddControllersWithConfig(
        this IServiceCollection services
    )
    {
        services.AddControllers(options => { options.Filters.Add<HttpExceptionFilter>(); })
            .AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new DefaultNamingStrategy()
                };
            });
        return services;
    }

    private static IServiceCollection AddAuth(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(nameof(JwtSettings), jwtSettings);
        services.AddSingleton(jwtSettings);
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.AccessTokenSecret)),
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    ClockSkew = TimeSpan.Zero
                };
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = async context =>
                    {
                        var claimsPrincipal = context.Principal;
                        if (claimsPrincipal != null)
                        {
                            var id = Guid.Parse(claimsPrincipal.Claims.First().Value);
                            var userRepository = context.HttpContext.RequestServices.GetService<IUserRepository>()!;
                            var user = await userRepository.OnById(id, context.HttpContext.RequestAborted);
                            context.HttpContext.Items["User"] = user;
                        }
                    }
                };
            });
        return services;
    }
}