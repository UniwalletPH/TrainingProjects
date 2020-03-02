using EManager.Application.Interfaces;
using EManager.Application.SystemCommand.Queries;
using EManager.Domain.Entities;
using EManager.Domain.Enums;
using FluentValidation;
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
       
        public UserVM EmployeeInfo { get; set; }

       
        public class SaveInfoCommandHandler :  IRequestHandler<SaveInfoCommand, int>
        {
            private readonly IEManagerDbContext dbContext;

            public SaveInfoCommandHandler(IEManagerDbContext dbContext) 
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(SaveInfoCommand request, CancellationToken cancellationToken)
            {

                var _employeeInformation = new EmployeeInformation
                { 
                    FirstName = request.EmployeeInfo.Firstname,                  
                    LastName = request.EmployeeInfo.Lastname,
                    Address = request.EmployeeInfo.Address,
                    Username = request.EmployeeInfo.Username,
                    Password = request.EmployeeInfo.Password,  
                    Role = UserRole.Regular
                };

                dbContext.EmployeeInformation.Add(_employeeInformation);
                await dbContext.SaveChangesAsync();

                return _employeeInformation.ID;
            }
        }
    }
}
