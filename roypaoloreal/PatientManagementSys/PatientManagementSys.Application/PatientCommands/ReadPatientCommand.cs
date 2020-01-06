using MediatR;
using Microsoft.EntityFrameworkCore;
using PatientManagementSys.Application.Common.Base;
using PatientManagementSys.Application.Interfaces;
using PatientManagementSys.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PatientManagementSys.Application.PatientCommands
{
    public class ReadPatientCommand : IRequest<List<PatientRecords>>
    {
        private readonly PatientRecords patient;
        
        public ReadPatientCommand()
        {
            
        }

        public class ReadPatientCommandHandler : BaseRequestHandler, IRequestHandler<ReadPatientCommand, List<PatientRecords>>
        {
            public ReadPatientCommandHandler(IPatientManagementSysDbContext dbContext) : base(dbContext)
            {

            }
            public async Task<List<PatientRecords>> Handle(ReadPatientCommand request, CancellationToken cancellationToken)
            {
                var _patientRecordList = await dbContext.PatientRecords.ToListAsync();

                return _patientRecordList;
            }
        }

    }
}
