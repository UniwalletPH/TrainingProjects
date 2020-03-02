using EManager.Application.Interfaces;
using EManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EManager.Application.SystemCommand.Queries
{
    public class GetAllEmployeeQuery : IRequest<List<EmployeeInformation>>
    {
        public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, List<EmployeeInformation>>
        {
            private readonly IEManagerDbContext dbContext;
            public GetAllEmployeeQueryHandler(IEManagerDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public  async Task<List<EmployeeInformation>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
            {

             

                var _employeeList = await dbContext.EmployeeInformation.ToListAsync();


                return _employeeList;
               
            }
        }
    }
}
