using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StudentEnrollmentSystem.Application.Common.Behaviors;
using StudentEnrollmentSystem.Application.Schedule.Commands;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static StudentEnrollmentSystem.Application.Schedule.Commands.SubjectDetailsCheckerCommand;

namespace StudentEnrollmentSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddTransient(typeof(IValidator<SubjectDetailsCheckerCommand>), typeof(SubjectDetailsCheckerCommandValidator));

            return services;
        }
    }
}
