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
    public class SearchPatientByIdQuery : IRequest<PatientRecords>
    {
        private readonly long patientID;
        public SearchPatientByIdQuery(long patient)
        {
            patientID = patient;
        }

        public class SearchPatientByIdQueryHandler : IRequestHandler<SearchPatientByIdQuery, PatientRecords>
        {
            private readonly IPatientManagementSysDbContext dbContext;
            public SearchPatientByIdQueryHandler(IPatientManagementSysDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<PatientRecords> Handle(SearchPatientByIdQuery request, CancellationToken cancellationToken)
            {
                PatientRecords c = dbContext.PatientRecords.Find(request.patientID);
                if (c == null)
                {
                    throw new Exception("Patient not found!");
                }
                return c;
            }
        }
    }
}
