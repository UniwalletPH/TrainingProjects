using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentEnrollmentSystem.Application.Interfaces;
using StudentEnrollmentSystem.Infrastructure.Persistence;
using System;

namespace StudentEnrollmentSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<StudentEnrollmentSystemDbContext>();

            services.AddScoped<IStudentEnrollmentSystemDbContext>(provider => provider.GetService<StudentEnrollmentSystemDbContext>());

            return services;
        }
    }
}
