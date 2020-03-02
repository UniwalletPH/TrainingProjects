using EManager.Application.Interfaces;
using EManager.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EManager.Application.SystemCommand.Queries
{
    public class GetTimeOutDetailQuery : IRequest<DateTime?>
    {
        public int EmployeeID { get; set; }
        public class GetTimeOutDTRQueryHandler : IRequestHandler<GetTimeOutDetailQuery, DateTime?>
        {
            private readonly IEManagerDbContext dbContext;
            public GetTimeOutDTRQueryHandler(IEManagerDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<DateTime?> Handle(GetTimeOutDetailQuery request, CancellationToken cancellationToken)
            {
                var x = dbContext.EmployeeTimeRecords
                     .Where(a => a.EmployeeInformationID == request.EmployeeID
                     && a.RecordType == RecordType.TimeOut
                     && a.Time.Date == DateTime.Now.Date).SingleOrDefault();

                if (x != null)
                {
                    return x.Time;
                }
                else
                {
                    return null;
                }

              
            }
        }
    }
}

