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
    public class UpdateEmployeeLastNameCommand : IRequest<bool>
    {

        private readonly EmployeeInformation employeeInformation;
        private readonly string newLastName;
        public UpdateEmployeeLastNameCommand(EmployeeInformation selectedEmployee, string newLastName)
        {
            this.employeeInformation = selectedEmployee;
            this.newLastName = newLastName;
        }

        public class UpdateEmployeeLastNameCommandHandler : BaseRequestHandler, IRequestHandler<UpdateEmployeeLastNameCommand, bool>
        {
            public UpdateEmployeeLastNameCommandHandler(IEManagerDbContext dbContext) : base(dbContext)
            {
            }

            public async Task<bool> Handle(UpdateEmployeeLastNameCommand request, CancellationToken cancellationToken)
            {
                var entryToUpdate = dbContext.EmployeeInformation.Find(request.employeeInformation.ID);

                entryToUpdate.LastName = request.newLastName;
                await dbContext.SaveChangesAsync();


                return true;
            }
        }
    }
}
