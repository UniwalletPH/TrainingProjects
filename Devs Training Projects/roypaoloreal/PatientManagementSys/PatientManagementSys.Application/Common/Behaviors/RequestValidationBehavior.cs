using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PatientManagementSys.Application.Common.Behaviors
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<IRequest>> validators;
        public RequestValidationBehavior(IEnumerable<IValidator<IRequest>> validators)
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
}
