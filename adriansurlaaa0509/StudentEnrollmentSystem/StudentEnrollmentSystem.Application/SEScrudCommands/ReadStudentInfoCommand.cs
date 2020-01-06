using MediatR;
using StudentEnrollmentSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using StudentEnrollmentSystem.Application.Common.Base;
using StudentEnrollmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace StudentEnrollmentSystem.Application.SEScrudCommands
{
    public class ReadStudentInfoCommand : IRequest<List<StudentBasicInfo>>
    {
        public ReadStudentInfoCommand()
        {

        }

        public class ReadStudentInfoCommandHandler : BaseRequestHandler, IRequestHandler<ReadStudentInfoCommand, List<StudentBasicInfo>>
        {
            public ReadStudentInfoCommandHandler(IStudentEnrollmentSystemDbContext dbContext) : base(dbContext)
            {

            }

            public async Task<List<StudentBasicInfo>> Handle(ReadStudentInfoCommand request, CancellationToken cancellationToken)
            {
                var _studentBasicInfoList = await dbContext.StudentBasicInfos.ToListAsync();
                return _studentBasicInfoList;
            }
        }
    }
}
