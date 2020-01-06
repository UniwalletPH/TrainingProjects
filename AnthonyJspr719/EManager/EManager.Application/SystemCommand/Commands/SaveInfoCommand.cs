using EManager.Application.Common.Base;
using EManager.Application.Interfaces;
using EManager.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EManager.Application.SystemCommand.Commands
{
    public class SaveInfoCommand : IRequest<int>
    {
        private readonly EmployeeInformation employeeInformation;

        public SaveInfoCommand(EmployeeInformation employeeInformation) {

            this.employeeInformation = employeeInformation;

        }

        public class SaveInfoCommandHandler : BaseRequestHandler, IRequestHandler<SaveInfoCommand, int>
        {
            public SaveInfoCommandHandler(IEManagerDbContext dbContext) : base(dbContext)
            { 
            
            }

            public async Task<int> Handle(SaveInfoCommand request, CancellationToken cancellationToken)
            {
                EmployeeInformation employeeInformation = new EmployeeInformation 
                {
                    FirstName = request.employeeInformation.FirstName,
                    MiddleName = request.employeeInformation.MiddleName,
                    LastName = request.employeeInformation.LastName,
                    Address = request.employeeInformation.Address,
                    DateOfBirth = request.employeeInformation.DateOfBirth,
                    Age = request.employeeInformation.Age
                };


                dbContext.EmployeeInformation.Add(employeeInformation);
                await dbContext.SaveChangesAsync();

                return employeeInformation.ID;
            }
        }
    }
}
