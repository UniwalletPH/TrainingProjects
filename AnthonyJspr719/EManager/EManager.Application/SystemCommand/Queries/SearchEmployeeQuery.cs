using EManager.Application.Common.Base;
using EManager.Application.Interfaces;
using EManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EManager.Application.SystemCommand.Commands
{
    public class SearchEmployeeQuery : IRequest<List<EmployeeInformation>>
    {
        private readonly string toFind;
        public SearchEmployeeQuery(string toFind)
        {
            this.toFind = toFind;
        }

        public class SearchEmployeeLastNameCommandHandler :  IRequestHandler<SearchEmployeeQuery, List<EmployeeInformation>>
        {
            private readonly IEManagerDbContext dbContext;
            public SearchEmployeeLastNameCommandHandler(IEManagerDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EmployeeInformation>> Handle(SearchEmployeeQuery request, CancellationToken cancellationToken)
            {
                var _employeeSearched = dbContext.EmployeeInformation.Where
                    (a => a.LastName.Contains(request.toFind) 
                    || a.FirstName.Contains(request.toFind) 
                    || a.MiddleName.Contains(request.toFind));

                return _employeeSearched.ToList();
            }
        }
    }
}
