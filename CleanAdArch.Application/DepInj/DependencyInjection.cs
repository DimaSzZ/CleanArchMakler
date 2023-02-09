using System.Reflection;
using CleanAdArch.Application.Behaviors;
using CleanAdArch.Application.Commands.AdminActions.CUD_Category.CreateCategory;
using CleanAdArch.Application.Commands.AdminActions.CUD_Category.DeleteCategory;
using CleanAdArch.Application.Commands.AdminActions.CUD_Category.UpdateCategory;
using CleanAdArch.Application.Commands.AdminActions.CUD_City.CreateCity;
using CleanAdArch.Application.Commands.AdminActions.CUD_City.DeleteCity;
using CleanAdArch.Application.Commands.AdminActions.CUD_City.UpdateCity;
using CleanAdArch.Application.Commands.AdminActions.CUD_SubCategory.CreateSubCategory;
using CleanAdArch.Application.Commands.AdminActions.CUD_SubCategory.DeleteSubCategory;
using CleanAdArch.Application.Commands.AdminActions.CUD_SubCategory.UpdateSubCategory;
using CleanAdArch.Application.Commands.AdminUserActions.CUD_Ads.CreateAd;
using CleanAdArch.Application.Commands.AdminUserActions.CUD_Ads.DeleteAd;
using CleanAdArch.Application.Commands.AdminUserActions.CUD_Ads.UpdateAd;
using CleanAdArch.Application.Commands.Auth.ChangePassword;
using CleanAdArch.Application.Commands.Auth.Login;
using CleanAdArch.Application.Commands.Auth.Refresh;
using CleanAdArch.Application.Commands.Auth.Registration;
using CleanAdArch.Application.Commands.Auth.Revoke;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanAdArch.Application.DepInj;

public static class DependencyInjection 
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddValidators();
        services.AddBehaviors();
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }

    private static IServiceCollection AddValidators(
        this IServiceCollection services
    )
    {
        services.AddScoped<IValidator<CreateCategoryCommand>,CreateCategoryValidator>();
        services.AddScoped<IValidator<DeleteCategoryCommand>,DeleteCategoryValidator>();
        services.AddScoped<IValidator<UpdateCategoryCommand>,UpdateCategoryValidator>();
        services.AddScoped<IValidator<CreateCityCommand>,CreateCityValidator>();
        services.AddScoped<IValidator<DeleteCityCommand>,DeleteCityValidator>();
        services.AddScoped<IValidator<UpdateCityCommand>,UpdateCityValidator>();
        services.AddScoped<IValidator<CreateSubCategoryCommand>,CreateSubCategoryValidator>();
        services.AddScoped<IValidator<DeleteSubCategoryCommand>,DeleteSubCategoryValidator>();
        services.AddScoped<IValidator<UpdateSubCategoryCommand>,UpdateSubCategoryValidator>();
        services.AddScoped<IValidator<CreateAdCommand>,CreateAdValidator>();
        services.AddScoped<IValidator<UpdateAdCommand>,UpdateAdValidator>();
        services.AddScoped<IValidator<DeleteAdCommand>,DeleteAdValidator>();
        services.AddScoped<IValidator<ChangePasswordCommand>,ChangePasswordValidator>();
        services.AddScoped<IValidator<RefreshTokenCommand>,RefreshTokenValidator>();
        services.AddScoped<IValidator<LoginCommand>,LoginCommandValidator>();
        services.AddScoped<IValidator<RegistrationCommand>,RegistrationCommandValidator>();
        services.AddScoped<IValidator<RevokeTokenCommand>,RevokeTokenValidator>();
        return services;
    }
    private static IServiceCollection AddBehaviors(
        this IServiceCollection services
    )
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}