using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using StudentEnrollmentSystem.Application.Common.Base;
using StudentEnrollmentSystem.Application.Interfaces;
using StudentEnrollmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentEnrollmentSystem.Application.SEScrudCommands
{
    public class SearchStudentByIDCommand : IRequest<StudentBasicInfo>
    {
        private readonly int searchedID;

        public SearchStudentByIDCommand(int searchedID)
        {
            this.searchedID = searchedID;
        }

        public class SearchStudentByIDCommandHandler : BaseRequestHandler, IRequestHandler<SearchStudentByIDCommand, StudentBasicInfo>
        {

            public SearchStudentByIDCommandHandler(IStudentEnrollmentSystemDbContext dbContext) : base(dbContext)
            {

            }

            public async Task<StudentBasicInfo> Handle(SearchStudentByIDCommand request, CancellationToken cancellationToken)
            {
                StudentBasicInfo _searchedByIDStudentBasicInfoList = dbContext.StudentBasicInfos.Find(request.searchedID);

                return _searchedByIDStudentBasicInfoList;
            }
        }
    }
}
