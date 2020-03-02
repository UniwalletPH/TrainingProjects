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
    public class SaveTimeOutCommand : IRequest<EmployeeInformation>
    {
        private readonly int id;
        public SaveTimeOutCommand(int id)
        {
            this.id = id;
        }

        public class SaveTimeOutCommandHandler : IRequestHandler<SaveTimeOutCommand, EmployeeInformation>
        {
            private readonly IEManagerDbContext dbContext;
            public SaveTimeOutCommandHandler(IEManagerDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<EmployeeInformation> Handle(SaveTimeOutCommand request, CancellationToken cancellationToken)
            {
                var _employeeToTimeOut = dbContext.EmployeeInformation.Find(request.id);

                EmployeeTimeRecords _timeRecord = new EmployeeTimeRecords
                {
                    EmployeeInformationID = _employeeToTimeOut.ID,
                    RecordType = RecordType.TimeOut,
                    Time = DateTime.Now
                };

                dbContext.EmployeeTimeRecords.Add(_timeRecord);
                await dbContext.SaveChangesAsync();

                return _employeeToTimeOut;
            }
        }
    }
}
