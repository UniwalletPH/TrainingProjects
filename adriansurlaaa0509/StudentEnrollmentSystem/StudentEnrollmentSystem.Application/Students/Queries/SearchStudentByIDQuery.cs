using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

using StudentEnrollmentSystem.Application.Interfaces;
using StudentEnrollmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentEnrollmentSystem.Application.Students.Queries
{
    public class SearchStudentByIDQuery : IRequest<StudentBasicInfo>
    {
        private readonly int searchedID;

        public SearchStudentByIDQuery(int searchedID)
        {
            this.searchedID = searchedID;
        }

        public class SearchStudentByIDCommandHandler : IRequestHandler<SearchStudentByIDQuery, StudentBasicInfo>
        {
            private readonly IStudentEnrollmentSystemDbContext dbContext;
            public SearchStudentByIDCommandHandler(IStudentEnrollmentSystemDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<StudentBasicInfo> Handle(SearchStudentByIDQuery request, CancellationToken cancellationToken)
            {
                StudentBasicInfo _searchedByIDStudentBasicInfoList = dbContext.StudentBasicInfos.Find(request.searchedID);

                return _searchedByIDStudentBasicInfoList;
            }
        }
    }
}
