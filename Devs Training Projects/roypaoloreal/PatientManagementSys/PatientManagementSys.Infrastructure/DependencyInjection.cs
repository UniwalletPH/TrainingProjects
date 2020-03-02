using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientManagementSys.Application.Interfaces;
using PatientManagementSys.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientManagementSys.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<PatientManagementSysDbContext>();
            services.AddScoped<IPatientManagementSysDbContext>(provider => provider.GetService<PatientManagementSysDbContext>());

            return services;
        }
    }
}
