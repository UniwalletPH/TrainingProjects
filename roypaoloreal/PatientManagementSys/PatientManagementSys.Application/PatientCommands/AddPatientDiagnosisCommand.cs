using MediatR;
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
        private readonly int PatientID;
        private readonly string Diseases;

        public AddPatientDiagnosisCommand(int patientID, string diseases)
        {
            PatientID = patientID;
            Diseases = diseases;
        }

        public class AddPatientDiagnosisCommandHandler : IRequestHandler<AddPatientDiagnosisCommand, PatientRecords>
        {
            private readonly IPatientManagementSysDbContext dbContext;
            public AddPatientDiagnosisCommandHandler(IPatientManagementSysDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<PatientRecords> Handle(AddPatientDiagnosisCommand request, CancellationToken cancellationToken)
            {
                var c = dbContext.PatientRecords.Find(request.PatientID);

                if (c == null)
                {
                    throw new Exception("Patient not found!");
                }

                c.diseases = request.Diseases;

                await dbContext.SaveChangesAsync();

                return c;
            }
        }
    }
}
