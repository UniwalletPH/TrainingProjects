
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
        private readonly int id;

        public DeleteInfoCommand(int id)
        {
            this.id = id;
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
                var _employeeToDelete = dbContext.EmployeeInformation.Find(request.id);

                dbContext.EmployeeInformation.Remove(_employeeToDelete);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }

    }
}
