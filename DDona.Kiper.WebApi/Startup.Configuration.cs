using System;
using System.Text;
using DDona.Kiper.Infra;
using DDona.Kiper.Service;
using DDona.Kiper.WebApi.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

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
            services.AddDbContext<KiperDesafioContext>(opt => opt.UseMySql(configuration.GetConnectionString("Default")));
        }

        internal static void ConfigureAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            AppSettings settings = configuration.GetSection("AppSettings").Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(settings.TokenConfiguration.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        internal static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
