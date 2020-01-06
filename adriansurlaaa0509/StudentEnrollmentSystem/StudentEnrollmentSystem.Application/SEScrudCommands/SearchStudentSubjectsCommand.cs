using MediatR;
using StudentEnrollmentSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using StudentEnrollmentSystem.Application.Common.Base;
using StudentEnrollmentSystem.Domain.Entities;
using System.Linq;

namespace StudentEnrollmentSystem.Application.SEScrudCommands
{
    public class SearchStudentSubjectsCommand : IRequest<List<StudentSubjectList>>
    {
        private readonly int searchSubjectDetailsID;
        public SearchStudentSubjectsCommand(int searchSubjectDetailsID)
        {
            this.searchSubjectDetailsID = searchSubjectDetailsID;
        }

        public class SearchStudentSubjectsCommandHandler : BaseRequestHandler, IRequestHandler<SearchStudentSubjectsCommand, List<StudentSubjectList>>
        {
            public SearchStudentSubjectsCommandHandler(IStudentEnrollmentSystemDbContext dbContext) : base(dbContext)
            {

            }

            public async Task<List<StudentSubjectList>> Handle(SearchStudentSubjectsCommand request, CancellationToken cancellationToken)
            {
                List<StudentSubjectList> _searchedByIDStudentSubjectDetails = dbContext.StudentSubjectLists.Where(a => a.StudentBasicInfoID == request.searchSubjectDetailsID).ToList();

                return _searchedByIDStudentSubjectDetails;
            }
        }
    }
}
