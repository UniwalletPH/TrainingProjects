using EManager.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EManager.Application.SystemCommand.Commands
{
    public class UpdateEmployeeAddressCommand : IRequest<bool>
    {
        private readonly int id;
        private readonly string address;
        public UpdateEmployeeAddressCommand(int id, string address)
        {
            this.address = address;
            this.id = id;
        }

        public class UpdateEmployeeAddressCommandHandler : IRequestHandler<UpdateEmployeeAddressCommand, bool>
        {
            private readonly IEManagerDbContext dbContext;

            public UpdateEmployeeAddressCommandHandler(IEManagerDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UpdateEmployeeAddressCommand request, CancellationToken cancellationToken)
            {
                var _employeeToUpdate = dbContext.EmployeeInformation.Find(request.id);
                _employeeToUpdate.Address = request.address;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }


    }
}
