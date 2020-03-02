using EManager.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EManager.Application.SystemCommand.Queries
{
    public class GetDailyReportQuery : IRequest<List<DailyReportVM>>
    {
        public class GetDailyReportQueryHandler : IRequestHandler<GetDailyReportQuery, List<DailyReportVM>>
        {
            private readonly IEManagerDbContext dbContext;
            private readonly IMediator mediator;
            public GetDailyReportQueryHandler(IEManagerDbContext dbContext, IMediator mediator)
            {
                this.dbContext = dbContext;
                this.mediator = mediator;
            }

            public async Task<List<DailyReportVM>> Handle(GetDailyReportQuery request, CancellationToken cancellationToken)
            {

                var _ret = new List<DailyReportVM>();

                var _allEmployee = await dbContext.EmployeeInformation.ToListAsync();


                foreach (var item in _allEmployee)
                {
                    var _timeIn = await mediator.Send(new GetTimeInDetailsQuery { EmployeeID = item.ID});
                    var _timeOut = await mediator.Send(new GetTimeOutDetailQuery { EmployeeID = item.ID});

                    var report = new DailyReportVM
                    { 
                       ID = item.ID,
                       Firstname = item.FirstName,
                       Lastname = item.LastName,
                       TimeIn = _timeIn,
                       TimeOut = _timeOut

                    };

                    _ret.Add(report);
   
                }

                return _ret;
            }
        }
    }
}
