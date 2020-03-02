using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentEnrollmentSystem.Application;
using StudentEnrollmentSystem.Application.Interfaces;
using StudentEnrollmentSystem.Infrastructure;
using StudentEnrollmentSystem.Infrastructure.Persistence;
using System.IO;

namespace Student_Enrollment_System
{
    public static class ServiceRegistration
    {
        static IServiceCollection _services;

        public static ServiceProvider ServiceProvider
        {
            get
            {
                if (_services == null) _services = new ServiceCollection();

                var _builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: true);

                var _config = _builder.Build();

                _services.AddInfrastructure(_config);
                _services.AddApplication();

                var _serviceProvider = _services.BuildServiceProvider();

                return _serviceProvider;
            }
        }
    }
}
