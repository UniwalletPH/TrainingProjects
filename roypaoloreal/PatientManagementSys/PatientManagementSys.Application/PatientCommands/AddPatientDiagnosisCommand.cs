using MediatR;
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
    public class AddPatientDiagnosisCommand : IRequest<PatientRecords>
    {

        private readonly PatientRecords patient;
        public AddPatientDiagnosisCommand(PatientRecords patient)
        {
            this.patient = patient;
        }

        public class AddPatientDiagnosisCommandHandler : BaseRequestHandler, IRequestHandler<AddPatientDiagnosisCommand, PatientRecords>
        {
            public AddPatientDiagnosisCommandHandler(IPatientManagementSysDbContext dbContext) : base(dbContext)
            {

            }
            public async Task<PatientRecords> Handle(AddPatientDiagnosisCommand request, CancellationToken cancellationToken)
            {
                var c = dbContext.PatientRecords.Find(request.patient.ID);
                c.diseases = request.patient.diseases;

                await dbContext.SaveChangesAsync();
                return c;
            }
        }
    }
}
