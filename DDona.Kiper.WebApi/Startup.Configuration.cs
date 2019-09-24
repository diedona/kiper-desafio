using System;
using DDona.Kiper.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDona.Kiper.WebApi
{
    public class StartupConfiguration
    {
        internal static void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("AllCorsEnabled", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));
        }

        internal static void ConfigureDB(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KiperDesafioContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default")));
        }
    }
}
