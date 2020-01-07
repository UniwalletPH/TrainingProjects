using MediatR;
using StudentEnrollmentSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using StudentEnrollmentSystem.Domain.Entities;
using System.Linq;

namespace StudentEnrollmentSystem.Application.SEScrudCommands
{
    public class SearchStudentSubjectsQuery : IRequest<IEnumerable<StudentSubjectList>>
    {
        private readonly int searchSubjectDetailsID;
        public SearchStudentSubjectsQuery(int searchSubjectDetailsID)
        {
            this.searchSubjectDetailsID = searchSubjectDetailsID;
        }

        public class SearchStudentSubjectsCommandHandler : IRequestHandler<SearchStudentSubjectsQuery, IEnumerable<StudentSubjectList>>
        {
            private readonly IStudentEnrollmentSystemDbContext dbContext;
            public SearchStudentSubjectsCommandHandler(IStudentEnrollmentSystemDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<StudentSubjectList>> Handle(SearchStudentSubjectsQuery request, CancellationToken cancellationToken)
            {
                List<StudentSubjectList> _searchedByIDStudentSubjectDetails = dbContext.StudentSubjectLists.Where(a => a.StudentBasicInfoID == request.searchSubjectDetailsID).ToList();

                return _searchedByIDStudentSubjectDetails;
            }
        }
    }
}
