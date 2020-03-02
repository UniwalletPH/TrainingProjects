using EManager.Application.Interfaces;
using EManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<EManagerDbContext>();

            services.AddScoped<IEManagerDbContext>(provider => provider.GetService<EManagerDbContext>());

            return services;
        
        }

    }
}
