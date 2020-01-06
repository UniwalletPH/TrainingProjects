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
    public class DeleteInfoCommand : IRequest<bool>
    {
        private readonly EmployeeInformation toDelete;

        public DeleteInfoCommand(EmployeeInformation toDelete)
        {
            this.toDelete = toDelete;
        }

        public class DeleteInfoCommandHandler : BaseRequestHandler, IRequestHandler<DeleteInfoCommand, bool>
        {

            public DeleteInfoCommandHandler(IEManagerDbContext dbContext) : base(dbContext) { }

            public async Task<bool> Handle(DeleteInfoCommand request, CancellationToken cancellationToken)
            {
                var employeeToDelete = dbContext.EmployeeInformation.Find(request.toDelete.ID);

                dbContext.EmployeeInformation.Remove(employeeToDelete);
                await dbContext.SaveChangesAsync();


                return true;
            }
        }

    }
}
