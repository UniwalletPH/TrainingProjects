using EManager.Application.SystemCommand.Commands;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static EManager.Application.SystemCommand.Commands.SaveInfoCommand;

namespace EManager.Application.Common.Behaviors
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var _context = new ValidationContext(request);

            var _failures = validators
                .Select(a => a.Validate(_context))
                .SelectMany(a => a.Errors)
                .Where(a => a != null)
                .ToList();

            if (_failures.Any())
            {
                throw new ValidationException(_failures);
            }

            return next();
        }
    }

    public static class RequestValidationInjection
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services, Assembly assembly)
        {
            assembly.GetTypes()
                .Where(t => t.BaseType != null 
                        && t.BaseType.IsGenericType 
                        && t.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>))
                .Select(t => new
                {
                    Implementation = t,
                    Service = typeof(IValidator<>).MakeGenericType( t.BaseType.GenericTypeArguments[0])
                })
                .ToList()
                .ForEach(a =>
                {
                    services.AddTransient(a.Service, a.Implementation);
                });

            return services;
        }
    }
}
