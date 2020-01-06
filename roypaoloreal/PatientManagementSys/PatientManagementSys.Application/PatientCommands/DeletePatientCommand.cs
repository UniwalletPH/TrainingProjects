﻿using MediatR;
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
        private readonly int patient;

        public DeletePatientCommand(int patient)
        {
            this.patient = patient;
        }

        public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, PatientRecords>
        {
            private readonly IPatientManagementSysDbContext dbContext;
            public DeletePatientCommandHandler(IPatientManagementSysDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<PatientRecords> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
            {
                var c = dbContext.PatientRecords.Find(request.patient);
                dbContext.PatientRecords.Remove(c);

                await dbContext.SaveChangesAsync();
                return c;
            }
        }

    }
}
