using EManager.Application.Common.Base;
using EManager.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EManager.Application.SystemCommand.Commands
{
    public class CheckEmployeeAgeCommand : IRequest<bool>
    {
        private readonly int EmployeeAge;

        public CheckEmployeeAgeCommand(int EmployeeAge)
        {

            this.EmployeeAge = EmployeeAge;
        }

        public class CheckEmployeeAgeCommandHandler : BaseRequestHandler, IRequestHandler<CheckEmployeeAgeCommand, bool>
        {

            public CheckEmployeeAgeCommandHandler(IEManagerDbContext dbContext) : base(dbContext)
            {}

            public async Task<bool> Handle(CheckEmployeeAgeCommand request, CancellationToken cancellationToken)
            {
                if (request.EmployeeAge >= 18)
                {
                    return true;
                }  else
                {
                    return false;
                }
           }
        }

    }
}
