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
    public class DeletePatientCommand : IRequest
    {
        private readonly long patientID;

        public DeletePatientCommand(long patientID)
        {
            this.patientID = patientID;
        }

        public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand>
        {
            private readonly IPatientManagementSysDbContext dbContext;
            public DeletePatientCommandHandler(IPatientManagementSysDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<Unit> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
            {
                var c = dbContext.PatientRecords.Find(request.patientID);

                if (c != null)
                {
                    dbContext.PatientRecords.Remove(c);

                    await dbContext.SaveChangesAsync();
                }

                return Unit.Value;
            }
        }

    }
}
