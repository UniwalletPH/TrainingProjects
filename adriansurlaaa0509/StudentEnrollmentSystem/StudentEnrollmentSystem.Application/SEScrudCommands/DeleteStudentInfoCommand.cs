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
    public class DeleteStudentInfoCommand : IRequest<bool>
    {
        private readonly StudentBasicInfo myStudentBasicInfo;
        public DeleteStudentInfoCommand(StudentBasicInfo myStudentBasicInfo)
        {
            this.myStudentBasicInfo = myStudentBasicInfo;
        }

        public class DeleteStudentInfoCommandHandler : BaseRequestHandler, IRequestHandler<DeleteStudentInfoCommand, bool>
        {
            public DeleteStudentInfoCommandHandler(IStudentEnrollmentSystemDbContext dbContext) : base(dbContext)
            {

            }

            public async Task<bool> Handle(DeleteStudentInfoCommand request, CancellationToken cancellationToken)
            {
                var _deleteStudentInfo = dbContext.StudentSubjectLists.Find(request.myStudentBasicInfo.ID);

                dbContext.StudentSubjectLists.Remove(_deleteStudentInfo);

                await dbContext.SaveChangesAsync();


                return true;
            }
        }
    }
}
