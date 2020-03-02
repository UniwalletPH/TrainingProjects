using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using StudentEnrollmentSystem.Domain.Entities;

using System.Threading.Tasks;
using System.Threading;
using StudentEnrollmentSystem.Application.Interfaces;
using System.Linq;

namespace StudentEnrollmentSystem.Application.Students.Queries
{
    public class SearchByKeywordQuery : IRequest<IEnumerable<StudentBasicInfo>>
    {
        private readonly string searchKeyword;
        public SearchByKeywordQuery(string searchKeyword)
        {
            this.searchKeyword = searchKeyword;
        }

        public class SearchByKeywordCommandHandler : IRequestHandler<SearchByKeywordQuery, IEnumerable<StudentBasicInfo>>
        {
            private readonly IStudentEnrollmentSystemDbContext dbContext;
            public SearchByKeywordCommandHandler(IStudentEnrollmentSystemDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IEnumerable<StudentBasicInfo>> Handle(SearchByKeywordQuery request, CancellationToken cancellationToken)
            {

                var _searchedKeyword = dbContext.StudentBasicInfos.Where(a => a.StudentLastName.Contains(request.searchKeyword) || 
                                                                         a.StudentFirstName.Contains(request.searchKeyword) || 
                                                                         a.StudentMiddleName.Contains(request.searchKeyword));

                return _searchedKeyword.ToList();
            }
        }
    }
}
