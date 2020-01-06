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
        private readonly PatientRecords patient;
        public UpdatePatientRecordCommand(PatientRecords patient)
        {
            this.patient = patient;
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

                var c = dbContext.PatientRecords.Find(request.patient.ID);
                c.LastName = request.patient.LastName;
                c.FirstName = request.patient.FirstName;
                c.MiddleName = request.patient.MiddleName;

                await dbContext.SaveChangesAsync();
                return c;
                }
            }
        }

    }

