using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StudentEnrollmentSystem.Application.Common.Behaviors;
using System.Reflection;

namespace StudentEnrollmentSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddFluentValidation(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
