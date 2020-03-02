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
    public class SaveTimeOutCommand : IRequest<int>
    {
        public int ID { get; set; }

        public class SaveTimeOutCommandHandler : IRequestHandler<SaveTimeOutCommand, int>
        {
            private readonly IEManagerDbContext dbContext;
            public SaveTimeOutCommandHandler(IEManagerDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(SaveTimeOutCommand request, CancellationToken cancellationToken)
            {
              
                EmployeeTimeRecords _timeRecord = new EmployeeTimeRecords
                {
                    EmployeeInformationID = request.ID,
                    RecordType = RecordType.TimeOut,
                    Time = DateTime.Now
                };

                dbContext.EmployeeTimeRecords.Add(_timeRecord);
                await dbContext.SaveChangesAsync();

                return _timeRecord.EmployeeInformationID;
            }
        }
    }
}
