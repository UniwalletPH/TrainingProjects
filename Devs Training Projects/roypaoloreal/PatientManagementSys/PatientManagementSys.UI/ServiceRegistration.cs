using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientManagementSys.Application;
using PatientManagementSys.Application.Interfaces;
using PatientManagementSys.Infrastructure;
using PatientManagementSys.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PatientManagementSys.UI
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
                    .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true);

                var _config = _builder.Build();

                _services.AddInfrastructure(_config);
                _services.AddApplication();

                var _serviceProvider = _services.BuildServiceProvider();

                return _serviceProvider;
            }
        }
    }
}
