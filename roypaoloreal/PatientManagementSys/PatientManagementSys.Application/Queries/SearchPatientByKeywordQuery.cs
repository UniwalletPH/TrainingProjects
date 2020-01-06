using MediatR;
using PatientManagementSys.Application.Interfaces;
using PatientManagementSys.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
namespace PatientManagementSys.Application.PatientCommands
{
    public class SearchPatientByKeywordQuery : IRequest<IEnumerable<PatientRecords>>
    {
        private readonly string patient;
        public SearchPatientByKeywordQuery(string patient)
        {
            this.patient = patient;
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
                         where a.LastName.Contains(request.patient) 
                            || a.FirstName.Contains(request.patient) 
                            || a.MiddleName.Contains(request.patient)
                         select new PatientRecords
                         {
                             ID = a.ID,
                             LastName = a.LastName,
                             FirstName = a.FirstName,
                             MiddleName = a.MiddleName
                         };
                var x = _q.ToString();
                return _q.ToList();
            }
        }
    }
}
