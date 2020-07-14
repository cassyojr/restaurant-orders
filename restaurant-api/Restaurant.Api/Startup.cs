using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Restaurant.Api.Extensions;
using Restaurant.Api.Infrastructure;
using Restaurant.IoC;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Restaurant.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly string AllowedOrigins = "AllowedOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var allowedOriginsConfig = Configuration.GetSection(AllowedOrigins).Get<string[]>();

            services.AddCors(options =>
            {
                options.AddPolicy(AllowedOrigins,
                builder =>
                {
                    builder
                    .WithOrigins(allowedOriginsConfig)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });

            services.AddInfrastructure(Configuration);
            services.AddApplicationServices();

            services
                .AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerServices(Configuration);
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ExecuteMigrations();
            app.UseGlobalExceptionHandler(loggerFactory);
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Restaurant API");
                options.DocExpansion(DocExpansion.None);
            });

            app.UseRouting();
            app.UseCors(AllowedOrigins);

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
