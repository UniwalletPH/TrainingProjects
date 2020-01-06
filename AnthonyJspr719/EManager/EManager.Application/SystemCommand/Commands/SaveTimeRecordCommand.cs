using EManager.Application.Common.Base;
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
    public class SaveTimeRecordCommand : IRequest<bool>
    {

        private readonly EmployeeTimeRecords employeeTimeRecords;
      
        public SaveTimeRecordCommand( EmployeeTimeRecords record )
        {         
            this.employeeTimeRecords = record;         
        }

        public class SaveTimeRecordCommandHandler : BaseRequestHandler, IRequestHandler<SaveTimeRecordCommand, bool>
        {
            public SaveTimeRecordCommandHandler(IEManagerDbContext dbContext) : base(dbContext) { }

            public async Task<bool> Handle(SaveTimeRecordCommand request, CancellationToken cancellationToken)
            {

                if (request.employeeTimeRecords.RecordType == RecordType.TimeIn)

                {
                    EmployeeTimeRecords _timeRecord = new EmployeeTimeRecords
                    {
                        EmployeeInformationID = request.employeeTimeRecords.EmployeeInformationID,
                        RecordType = RecordType.TimeIn,
                        Time = request.employeeTimeRecords.Time
                    };

                    dbContext.EmployeeTimeRecords.Add(_timeRecord);
                    await dbContext.SaveChangesAsync();

                }
                else

                    if (request.employeeTimeRecords.RecordType == RecordType.TimeOut)
                {
                    EmployeeTimeRecords _timeRecord = new EmployeeTimeRecords
                    {
                        EmployeeInformationID = request.employeeTimeRecords.EmployeeInformationID,
                        RecordType = RecordType.TimeOut,
                        Time = request.employeeTimeRecords.Time
                    };

                    dbContext.EmployeeTimeRecords.Add(_timeRecord);
                    await dbContext.SaveChangesAsync();

                }

                return true;

            }
        }

    }
}
