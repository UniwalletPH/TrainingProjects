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
    public class DeletePatientCommand : IRequest<PatientRecords>
    {
        private readonly PatientRecords patient;

        public DeletePatientCommand(PatientRecords patient)
        {
            this.patient = patient;
        }

        public class DeletePatientCommandHandler : BaseRequestHandler, IRequestHandler<DeletePatientCommand, PatientRecords>
        {
            public DeletePatientCommandHandler(IPatientManagementSysDbContext dbContext) : base(dbContext)
            {

            }
            public async Task<PatientRecords> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
            {
                var c = dbContext.PatientRecords.Find(request.patient.ID);
                dbContext.PatientRecords.Remove(c);

                await dbContext.SaveChangesAsync();
                return c;
            }
        }

    }
}
