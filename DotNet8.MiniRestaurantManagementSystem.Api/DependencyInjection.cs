using DotNet8.MiniRestaurantManagementSystem.DbService.AppDbContextModels;
using DotNet8.MiniRestaurantManagementSystem.Modules.Features.Category;
using DotNet8.MiniRestaurantManagementSystem.Modules.Features.MenuItem;
using DotNet8.MiniRestaurantManagementSystem.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet8.MiniRestaurantManagementSystem.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
        {
            return services.AddDbContextService(builder)
                .AddDataAccessService()
                .AddBusinessLogicService()
                .AddCustomService();
        }

        private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            }, ServiceLifetime.Transient, ServiceLifetime.Transient);

            return services;
        }

        private static IServiceCollection AddDataAccessService(this IServiceCollection services)
        {
            return services.AddScoped<ICategoryService, CategoryService>()
                .AddScoped<IMenuItemService, MenuItemService>();
        }

        private static IServiceCollection AddBusinessLogicService(this IServiceCollection services)
        {
            return services.AddScoped<BL_Category>()
                .AddScoped<BL_MenuItem>();
        }

        private static IServiceCollection AddCustomService(this IServiceCollection services)
        {
            return services.AddScoped<DapperService>();
        }
    }
}
