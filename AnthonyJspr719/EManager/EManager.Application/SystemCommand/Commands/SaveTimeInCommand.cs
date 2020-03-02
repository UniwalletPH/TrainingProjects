
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
    public class SaveTimeInCommand : IRequest<EmployeeInformation>
    {

        private readonly int id;
      
        public SaveTimeInCommand(int id)
        {
            this.id = id;     
        }

        public class SaveTimeInCommandHandler : IRequestHandler<SaveTimeInCommand, EmployeeInformation>
        {
            private readonly IEManagerDbContext dbContext;
            public SaveTimeInCommandHandler(IEManagerDbContext dbContext) 
            {
                this.dbContext = dbContext;
            }

            public async Task<EmployeeInformation> Handle(SaveTimeInCommand request, CancellationToken cancellationToken)
            {

                var _employeeToTimeIn = dbContext.EmployeeInformation.Find(request.id);

                 EmployeeTimeRecords _timeRecord = new EmployeeTimeRecords
                 {
                      EmployeeInformationID = _employeeToTimeIn.ID,
                      RecordType = RecordType.TimeIn,
                      Time = DateTime.Now
                 };

                    dbContext.EmployeeTimeRecords.Add(_timeRecord);
                    await dbContext.SaveChangesAsync();

                    return _employeeToTimeIn;
            }
        }

    }
}
