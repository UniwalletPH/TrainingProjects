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
    public class TimeInCheckerQuery : IRequest<bool>
    {
        public int UserID { get; set; }

        public class TimeInCheckerQueryHandler : IRequestHandler<TimeInCheckerQuery, bool>
        {
            private readonly IEManagerDbContext dbContext;
            public TimeInCheckerQueryHandler(IEManagerDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(TimeInCheckerQuery request, CancellationToken cancellationToken)
            {
                var _retVal = dbContext.EmployeeTimeRecords
                    .Where(a => a.EmployeeInformationID == request.UserID
                    && a.RecordType == RecordType.TimeIn
                    && a.Time.Date == DateTime.Now.Date).SingleOrDefault();

                if (_retVal != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
