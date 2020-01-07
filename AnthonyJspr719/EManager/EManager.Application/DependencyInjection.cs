using EManager.Application.Common.Behaviors;
using EManager.Application.SystemCommand.Commands;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static EManager.Application.SystemCommand.Commands.SaveInfoCommand;

namespace EManager.Application
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
