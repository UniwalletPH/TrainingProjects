
using EManager.Application.Interfaces;
using EManager.Domain.Entities;
using EManager.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EManager.Application.SystemCommand.Commands
{
    public class SaveTimeInCommand : IRequest<int>
    {      
        public int ID { get; set; }

        public class SaveTimeInCommandHandler : IRequestHandler<SaveTimeInCommand, int>
        {
            private readonly IEManagerDbContext dbContext;
            public SaveTimeInCommandHandler(IEManagerDbContext dbContext) 
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(SaveTimeInCommand request, CancellationToken cancellationToken)
            {

                 EmployeeTimeRecords _timeRecord = new EmployeeTimeRecords
                 {
                      EmployeeInformationID = request.ID,
                      RecordType = RecordType.TimeIn,
                      Time = DateTime.Now
                 };

                    dbContext.EmployeeTimeRecords.Add(_timeRecord);
                    await dbContext.SaveChangesAsync();

                    return _timeRecord.EmployeeInformationID;
            }
        }

    }
}
