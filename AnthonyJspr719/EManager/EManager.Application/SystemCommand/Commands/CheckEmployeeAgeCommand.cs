
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
        private readonly int employeeAge;

        public CheckEmployeeAgeCommand(int employeeAge)
        {
            this.employeeAge = employeeAge;
        }

        public class CheckEmployeeAgeCommandHandler : IRequestHandler<CheckEmployeeAgeCommand, bool>
        {
            private readonly IEManagerDbContext dbContext;

            public CheckEmployeeAgeCommandHandler(IEManagerDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(CheckEmployeeAgeCommand request, CancellationToken cancellationToken)
            {
                if (request.employeeAge >= 18)
                {
                    return true;
                } 
                else
                {
                    return false;
                }
            }
        }


    }
}
