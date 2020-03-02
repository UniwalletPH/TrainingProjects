using MediatR;
using Microsoft.EntityFrameworkCore;
using PatientManagementSys.Application.Interfaces;
using PatientManagementSys.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PatientManagementSys.Application.PatientCommands
{
    public class ReadPatientQuery : IRequest<IEnumerable<PatientRecords>>
    {
        
        public ReadPatientQuery()
        {
            
        }

        public class ReadPatientQueryHandler : IRequestHandler<ReadPatientQuery, IEnumerable<PatientRecords>>
        {
            private readonly IPatientManagementSysDbContext dbContext;
            public ReadPatientQueryHandler(IPatientManagementSysDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            async Task<IEnumerable<PatientRecords>> IRequestHandler<ReadPatientQuery, IEnumerable<PatientRecords>>.Handle(ReadPatientQuery request, CancellationToken cancellationToken)
            {
                var _patientRecordList = await dbContext.PatientRecords.ToListAsync();

                return _patientRecordList;
            }
        }

    }
}
