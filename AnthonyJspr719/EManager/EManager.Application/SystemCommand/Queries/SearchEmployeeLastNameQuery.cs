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
    public class SearchEmployeeLastNameQuery : IRequest<List<EmployeeInformation>>
    {
        private readonly string toFind;
        public SearchEmployeeLastNameQuery(string toFind)
        {
            this.toFind = toFind;
        }

        public class SearchEmployeeLastNameCommandHandler : BaseRequestHandler, IRequestHandler<SearchEmployeeLastNameQuery, List<EmployeeInformation>>
        {

            public SearchEmployeeLastNameCommandHandler(IEManagerDbContext dbContext) : base(dbContext)
            { 
            
            }

            public async Task<List<EmployeeInformation>> Handle(SearchEmployeeLastNameQuery request, CancellationToken cancellationToken)
            {
                var entryToFind = dbContext.EmployeeInformation.Where(a => a.LastName.Contains(request.toFind) || a.FirstName.Contains(request.toFind) || a.MiddleName.Contains(request.toFind));


                return entryToFind.ToList();

            }
        }

       
    }
}
