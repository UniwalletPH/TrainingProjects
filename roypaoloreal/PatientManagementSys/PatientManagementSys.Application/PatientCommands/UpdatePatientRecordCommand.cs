using MediatR;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using PatientManagementSys.Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using PatientManagementSys.Domain.Entities;

namespace PatientManagementSys.Application
{
    public class UpdatePatientRecordCommand : IRequest<PatientRecords>
    {
        private readonly PatientRecords patientID;
        public UpdatePatientRecordCommand(PatientRecords patientID)
        {
            this.patientID = patientID;
        }

        public class UpdatePatientRecordCommandHandler : IRequestHandler<UpdatePatientRecordCommand, PatientRecords>
        {
            private readonly IPatientManagementSysDbContext dbContext;
            public UpdatePatientRecordCommandHandler(IPatientManagementSysDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<PatientRecords> Handle(UpdatePatientRecordCommand request, CancellationToken cancellationToken)
            {

                var c = dbContext.PatientRecords.Find(request.patientID.ID);
                if (c == null)
                {
                    throw new Exception("Patient not found!");
                }
                else
                {
                    c.LastName = request.patientID.LastName;
                    c.FirstName = request.patientID.FirstName;
                    c.MiddleName = request.patientID.MiddleName;
                }

               

                await dbContext.SaveChangesAsync();
                return c;
            }
        }
    }
}