using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using StudentEnrollmentSystem.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using StudentEnrollmentSystem.Application.Common.Base;
using StudentEnrollmentSystem.Application.Interfaces;

namespace StudentEnrollmentSystem.Application.Schedule.Commands
{
    public class AddSubjectsCommand : IRequest<StudentSubjects>
    {
        private readonly int _subjectID;
        public AddSubjectsCommand(int _subjectID)
        {
            this._subjectID = _subjectID;
        }

        public class AddSubjectsCommandHandler : IRequestHandler<AddSubjectsCommand, StudentSubjects>
        {
            private readonly IStudentEnrollmentSystemDbContext dbContext;
            public AddSubjectsCommandHandler(IStudentEnrollmentSystemDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<StudentSubjects> Handle(AddSubjectsCommand request, CancellationToken cancellationToken)
            {
                StudentSubjects _studentSubjectsID = dbContext.StudentSubjects.Find(request._subjectID);

                return _studentSubjectsID;
            }
        }
    }
}
