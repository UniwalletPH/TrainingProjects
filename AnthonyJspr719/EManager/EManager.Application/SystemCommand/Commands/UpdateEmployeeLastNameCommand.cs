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
        private readonly int id;
        private readonly string newLastName;
        public UpdateEmployeeLastNameCommand(int id, string newLastName)
        {
            this.id = id;
            this.newLastName = newLastName;
        }

        public class UpdateEmployeeLastNameCommandHandler :  IRequestHandler<UpdateEmployeeLastNameCommand, bool>
        {
            private readonly IEManagerDbContext dbContext;
            public UpdateEmployeeLastNameCommandHandler(IEManagerDbContext dbContext) 
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UpdateEmployeeLastNameCommand request, CancellationToken cancellationToken)
            {
                var _entryToUpdate = dbContext.EmployeeInformation.Find(request.id);

                _entryToUpdate.LastName = request.newLastName;
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}

