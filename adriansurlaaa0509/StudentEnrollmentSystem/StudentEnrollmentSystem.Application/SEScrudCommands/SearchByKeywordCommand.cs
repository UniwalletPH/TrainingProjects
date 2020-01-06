using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using StudentEnrollmentSystem.Domain.Entities;
using StudentEnrollmentSystem.Application.Common.Base;
using System.Threading.Tasks;
using System.Threading;
using StudentEnrollmentSystem.Application.Interfaces;
using System.Linq;

namespace StudentEnrollmentSystem.Application.SEScrudCommands
{
    public class SearchByKeywordCommand : IRequest<List<StudentBasicInfo>>
    {
        private readonly string searchKeyword;
        public SearchByKeywordCommand(string searchKeyword)
        {
            this.searchKeyword = searchKeyword;
        }

        public class SearchByKeywordCommandHandler : BaseRequestHandler, IRequestHandler<SearchByKeywordCommand, List<StudentBasicInfo>>
        {

            public SearchByKeywordCommandHandler(IStudentEnrollmentSystemDbContext dbContext) : base(dbContext)
            {

            }
            public async Task<List<StudentBasicInfo>> Handle(SearchByKeywordCommand request, CancellationToken cancellationToken)
            {

                var _searchedKeyword = dbContext.StudentBasicInfos.Where(a => a.StudentLastName.Contains(request.searchKeyword) || 
                                                                         a.StudentFirstName.Contains(request.searchKeyword) || 
                                                                         a.StudentMiddleName.Contains(request.searchKeyword));

                return _searchedKeyword.ToList();
            }
        }
    }
}
