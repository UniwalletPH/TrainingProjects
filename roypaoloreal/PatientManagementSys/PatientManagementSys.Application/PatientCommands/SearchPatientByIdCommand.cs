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
    public class SearchPatientByIdCommand : IRequest<PatientRecords>
    {
        private readonly PatientRecords patient;
        public SearchPatientByIdCommand(PatientRecords patient)
        {
            this.patient = patient;
        }

        public class SearchPatientByIdCommandHandler : BaseRequestHandler, IRequestHandler<SearchPatientByIdCommand, PatientRecords>
        {
            public SearchPatientByIdCommandHandler(IPatientManagementSysDbContext dbContext) : base(dbContext)
            {

            }

            public async Task<PatientRecords> Handle(SearchPatientByIdCommand request, CancellationToken cancellationToken)
            {
                PatientRecords c = dbContext.PatientRecords.Find(request.patient.ID);

                return c;
            }
        }
    }
}
