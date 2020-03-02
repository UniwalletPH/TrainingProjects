using EManager.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EManager.Application.SystemCommand.Commands
{
    public class UpdateEmployeeMiddleNameCommand : IRequest<bool>
    {
        private readonly int id;
        private readonly string middleName;
        public UpdateEmployeeMiddleNameCommand(int id, string middleName)
        {
            this.id = id;
            this.middleName = middleName;
        }

        public class UpdateEmployeeMiddleNameCommandHandler : IRequestHandler<UpdateEmployeeMiddleNameCommand, bool>
        {
            private readonly IEManagerDbContext dbContext;
            public UpdateEmployeeMiddleNameCommandHandler(IEManagerDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UpdateEmployeeMiddleNameCommand request, CancellationToken cancellationToken)
            {
                var _employeeToUpdate = dbContext.EmployeeInformation.Find(request.id);
                _employeeToUpdate.MiddleName = request.middleName;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }

    }
}
