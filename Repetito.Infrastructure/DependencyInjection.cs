using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repetito.Application.Common.Authentication;
using Repetito.Application.Common.Persistance;
using Repetito.Infrastructure.Authentication;
using Repetito.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repetito.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {

            services.AddAuth(config);

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DatabaseConnection"));
            });

            services.AddScoped<Func<ApplicationDbContext>>((provider) => provider.GetService<ApplicationDbContext>);
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configration)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
           // var jwtSettings = new JwtSettings();
           // configration.Bind(JwtSettings.SectionName, jwtSettings);
           //
           // services.AddSingleton(Options.Create(jwtSettings));
           // 
           //
           // services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
           //     .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
           //     {
           //         ValidateIssuer = true,
           //         ValidateAudience = true,
           //         ValidateLifetime = true,
           //         ValidateIssuerSigningKey = true,
           //         ValidIssuer = jwtSettings.Issuer,
           //         ValidAudience = jwtSettings.Audience,
           //         IssuerSigningKey = new SymmetricSecurityKey(
           //             Encoding.UTF8.GetBytes(jwtSettings.Secret))
           //     });

            return services;
        }

    }
}
