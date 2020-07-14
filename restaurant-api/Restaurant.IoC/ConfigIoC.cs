using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Infra.Context;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurant.Domain.Repository.Domain;
using Restaurant.Domain.Repository.Standard;
using Restaurant.Infra.Repository.Standard;
using Restaurant.Infra.Repository.Domain;
using Restaurant.Domain.Services.Domain;
using Restaurant.Application.Services.Domain;

namespace Restaurant.IoC
{
    public static class ConfigIoC
    {
        public static IApplicationBuilder ExecuteMigrations(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();

                if (context != null) context.Database.Migrate();
                else throw new NullReferenceException("Invalid context to execute migrations");
            }

            return app;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServer");

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}
