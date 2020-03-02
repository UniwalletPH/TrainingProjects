using MediatR;
using StudentEnrollmentSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using StudentEnrollmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace StudentEnrollmentSystem.Application.Students.Queries
{
    public class ReadStudentInfoQuery : IRequest<IEnumerable<StudentBasicInfo>>
    {
        public ReadStudentInfoQuery()
        {

        }

        public class ReadStudentInfoCommandHandler : IRequestHandler<ReadStudentInfoQuery, IEnumerable<StudentBasicInfo>>
        {
            private readonly IStudentEnrollmentSystemDbContext dbContext;
            public ReadStudentInfoCommandHandler(IStudentEnrollmentSystemDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<StudentBasicInfo>> Handle(ReadStudentInfoQuery request, CancellationToken cancellationToken)
            {
                var _studentBasicInfoList = await dbContext.StudentBasicInfos.ToListAsync();
                return _studentBasicInfoList;
            }
        }
    }
}
