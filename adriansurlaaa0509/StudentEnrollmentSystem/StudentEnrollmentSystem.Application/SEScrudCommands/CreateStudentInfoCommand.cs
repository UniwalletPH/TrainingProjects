using MediatR;
using StudentEnrollmentSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using StudentEnrollmentSystem.Application.Common.Base;
using StudentEnrollmentSystem.Domain.Entities;

namespace StudentEnrollmentSystem.Application.SEScrudCommands
{
    public class CreateStudentInfoCommand : IRequest<bool>
    {

        private readonly StudentBasicInfo myStudentBasicInfo;

        public CreateStudentInfoCommand(StudentBasicInfo myStudentBasicInfo)
        {
            this.myStudentBasicInfo = myStudentBasicInfo;
        }

        public class CreateStudentInfoCommandHandler : BaseRequestHandler, IRequestHandler<CreateStudentInfoCommand, bool>
        {
            public CreateStudentInfoCommandHandler(IStudentEnrollmentSystemDbContext dbContext) : base(dbContext)
            {

            }

            public async Task<bool> Handle(CreateStudentInfoCommand request, CancellationToken cancellationToken)
            {
                StudentBasicInfo _studentBasicInfo = new StudentBasicInfo
                {
                    StudentLastName = request.myStudentBasicInfo.StudentLastName,
                    StudentMiddleName = request.myStudentBasicInfo.StudentMiddleName,
                    StudentFirstName = request.myStudentBasicInfo.StudentFirstName,
                    StudentAge = request.myStudentBasicInfo.StudentAge,
                    StudentGender = request.myStudentBasicInfo.StudentGender,
                    StudentAddress = request.myStudentBasicInfo.StudentAddress,
                    StudentContactNumber = request.myStudentBasicInfo.StudentContactNumber,
                    StudentEmailAddress = request.myStudentBasicInfo.StudentEmailAddress
                };

                dbContext.StudentBasicInfos.Add(_studentBasicInfo);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
