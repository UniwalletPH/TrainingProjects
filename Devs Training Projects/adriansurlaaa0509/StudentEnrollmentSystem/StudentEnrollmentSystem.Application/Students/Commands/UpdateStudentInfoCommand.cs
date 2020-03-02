using MediatR;
using StudentEnrollmentSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using StudentEnrollmentSystem.Domain.Entities;

namespace StudentEnrollmentSystem.Application.Students.Commands
{
    public class UpdateStudentInfoCommand : IRequest<bool>
    {
        private readonly StudentBasicInfo myStudentBasicInfo;
        public UpdateStudentInfoCommand(StudentBasicInfo myStudentBasicInfo)
        {
            this.myStudentBasicInfo = myStudentBasicInfo;
        }

        public class UpdateStudentInfoCommandHandler : IRequestHandler<UpdateStudentInfoCommand, bool>
        {
            private readonly IStudentEnrollmentSystemDbContext dbContext;
            public UpdateStudentInfoCommandHandler(IStudentEnrollmentSystemDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UpdateStudentInfoCommand request, CancellationToken cancellationToken)
            {
                var _updated = dbContext.StudentBasicInfos.Find(request.myStudentBasicInfo.ID);

                _updated.StudentLastName = request.myStudentBasicInfo.StudentLastName;
                _updated.StudentFirstName = request.myStudentBasicInfo.StudentFirstName;
                _updated.StudentMiddleName = request.myStudentBasicInfo.StudentMiddleName;
                _updated.StudentAge = request.myStudentBasicInfo.StudentAge;
                _updated.StudentGender = request.myStudentBasicInfo.StudentGender;
                _updated.StudentAddress = request.myStudentBasicInfo.StudentAddress;
                _updated.StudentEmailAddress = request.myStudentBasicInfo.StudentEmailAddress;
                _updated.StudentContactNumber = request.myStudentBasicInfo.StudentContactNumber;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
