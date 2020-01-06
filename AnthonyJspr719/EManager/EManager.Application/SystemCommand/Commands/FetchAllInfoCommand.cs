using EManager.Application.Common.Base;
using EManager.Application.Interfaces;
using EManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EManager.Application.SystemCommand.Commands
{
    public class FetchAllInfoCommand : IRequest<List<EmployeeInformation>>
    {
        public FetchAllInfoCommand() { 
        
        
        }

        public class FetchAllInfoCommandHandler : BaseRequestHandler, IRequestHandler<FetchAllInfoCommand, List<EmployeeInformation>>
        {
            public FetchAllInfoCommandHandler(IEManagerDbContext dbContext) : base(dbContext)
            { 
            
            }

            public async Task<List<EmployeeInformation>> Handle(FetchAllInfoCommand request, CancellationToken cancellationToken)
            {
                var allInfo = await dbContext.EmployeeInformation.ToListAsync();

                return allInfo;


            }
        }

    }
}
