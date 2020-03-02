using EManager.Application.Interfaces;
using EManager.Domain.Enums;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EManager.Application.SystemCommand.Queries
{
    public class GetTimeInDetailsQuery : IRequest<DateTime?>
    {
        public int EmployeeID { get; set;  }
        public class GetTimeInDetailsQueryHandler : IRequestHandler<GetTimeInDetailsQuery, DateTime?>
        {
            private readonly IEManagerDbContext dbContext;
            public GetTimeInDetailsQueryHandler(IEManagerDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<DateTime?> Handle(GetTimeInDetailsQuery request, CancellationToken cancellationToken)
            {
                var x = dbContext.EmployeeTimeRecords
                     .Where(a => a.EmployeeInformationID == request.EmployeeID
                     && a.RecordType == RecordType.TimeIn
                     && a.Time.Date == DateTime.Now.Date).SingleOrDefault();

                if (x != null)
                {
                    return x.Time;
                }

                else
                {
                    return null ;
                }
                

            }
        }
    }
}
