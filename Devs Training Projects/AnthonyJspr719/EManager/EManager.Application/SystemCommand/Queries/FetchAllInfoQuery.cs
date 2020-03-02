
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
    public class FetchAllInfoQuery : IRequest<List<EmployeeInformation>>
    {
        public FetchAllInfoQuery() { 
        }

        public class FetchAllInfoCommandHandler : IRequestHandler<FetchAllInfoQuery, List<EmployeeInformation>>
        {

            private readonly IEManagerDbContext dbContext;

            public FetchAllInfoCommandHandler(IEManagerDbContext dbContext) 
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EmployeeInformation>> Handle(FetchAllInfoQuery request, CancellationToken cancellationToken)
            {
                var _allEmployeeInfo = await dbContext.EmployeeInformation.ToListAsync();

                return _allEmployeeInfo;
            }
        }

    }
}
