﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PatientManagementSys.Application.Interfaces;
using PatientManagementSys.Application.Queries;
using PatientManagementSys.Domain.Entities;

namespace PatientManagementSys.Application
{
    public class AddPatientCommand : IRequest<PatientRecords>
    {
        private readonly PatientRecords patient;
        public AddPatientCommand(PatientRecords patient)
        {
            this.patient = patient;
        }

        public class AddPatientCommandHandler : IRequestHandler<AddPatientCommand, PatientRecords>
        {
            private readonly IPatientManagementSysDbContext dbContext;
            
            public AddPatientCommandHandler(IPatientManagementSysDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            async Task<PatientRecords> IRequestHandler<AddPatientCommand, PatientRecords>.Handle(AddPatientCommand request, CancellationToken cancellationToken)
            {
                PatientRecords _registerPatient = new PatientRecords
                {
                    LastName = request.patient.LastName,
                    FirstName = request.patient.FirstName,
                    MiddleName = request.patient.MiddleName,
                    diseases = request.patient.diseases
                };

                dbContext.PatientRecords.Add(_registerPatient);
                await dbContext.SaveChangesAsync();

                return _registerPatient;
            }
        }
    }
}
