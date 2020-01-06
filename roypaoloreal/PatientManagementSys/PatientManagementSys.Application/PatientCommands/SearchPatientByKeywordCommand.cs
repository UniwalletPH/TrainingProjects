using MediatR;
using PatientManagementSys.Application.Common.Base;
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
    public class SearchPatientByKeywordCommand : IRequest<List<PatientRecords>>
    {
        private readonly string patient;
        public SearchPatientByKeywordCommand(string patient)
        {
            this.patient = patient;
        }

        public class SearchPatientByKeywordCommandHandler : BaseRequestHandler, IRequestHandler<SearchPatientByKeywordCommand,List<PatientRecords>>
        {
            

            public SearchPatientByKeywordCommandHandler(IPatientManagementSysDbContext dbContext) : base(dbContext)
            {

            }

            public async Task<List<PatientRecords>> Handle(SearchPatientByKeywordCommand request, CancellationToken cancellationToken)
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
