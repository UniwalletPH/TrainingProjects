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
        private readonly int ID;

        public DeleteInfoCommand(int id)
        {
            ID = id;
        }

        public class DeleteInfoCommandHandler : IRequestHandler<DeleteInfoCommand, bool>
        {
            private readonly IEManagerDbContext dbContext;

            public DeleteInfoCommandHandler(IEManagerDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(DeleteInfoCommand request, CancellationToken cancellationToken)
            {
                var employeeToDelete = dbContext.EmployeeInformation.Find(request.ID);

                dbContext.EmployeeInformation.Remove(employeeToDelete);
                await dbContext.SaveChangesAsync();


                return true;
            }
        }

    }
}
