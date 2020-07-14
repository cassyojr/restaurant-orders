using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Restaurant.Api.Infrastructure
{
    public static class ServicesConfiguration
    {

        public static IServiceCollection AddSwaggerServices(this IServiceCollection services, IConfiguration Configuration)
        {
            var swaggerApiVersion = "v1";
            var swaggerApiName = Configuration.GetValue<string>("SwaggerApiName");

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(name: swaggerApiVersion, new OpenApiInfo
                {
                    Title = swaggerApiName,
                    Version = swaggerApiVersion
                });
            });

            return services;
        }

    }
}
