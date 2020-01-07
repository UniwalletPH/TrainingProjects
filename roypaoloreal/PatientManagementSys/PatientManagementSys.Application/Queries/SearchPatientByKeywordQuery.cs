using MediatR;
using PatientManagementSys.Application.Interfaces;
using PatientManagementSys.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PatientManagementSys.Application.PatientCommands
{
    public class SearchPatientByKeywordQuery : IRequest<IEnumerable<PatientRecords>>
    {
        private readonly string patientID;
        public SearchPatientByKeywordQuery(string patient)
        {
            patientID = patient;
        }

        public class SearchPatientByKeywordQueryHandler : IRequestHandler<SearchPatientByKeywordQuery,IEnumerable<PatientRecords>>
        {
            private readonly IPatientManagementSysDbContext dbContext;

            public SearchPatientByKeywordQueryHandler(IPatientManagementSysDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<PatientRecords>> Handle(SearchPatientByKeywordQuery request, CancellationToken cancellationToken)
            {


                var _q = from a in dbContext.PatientRecords
                         where a.LastName.Contains(request.patientID)
                            || a.FirstName.Contains(request.patientID)
                            || a.MiddleName.Contains(request.patientID)
                            || a.diseases.Contains(request.patientID)
                         select a;
                if (!_q.Any())
                {
                    throw new Exception("Patient not found!");
                }
                return await _q.ToListAsync();
            }
        }
    }
}
