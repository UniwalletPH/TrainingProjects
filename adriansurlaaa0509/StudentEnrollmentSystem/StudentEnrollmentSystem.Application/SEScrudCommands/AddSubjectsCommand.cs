using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using StudentEnrollmentSystem.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using StudentEnrollmentSystem.Application.Common.Base;
using StudentEnrollmentSystem.Application.Interfaces;

namespace StudentEnrollmentSystem.Application.SEScrudCommands
{
    public class AddSubjectsCommand : IRequest<StudentSubjects>
    {
        private readonly int _subjectID;
        public AddSubjectsCommand(int _subjectID)
        {
            this._subjectID = _subjectID;
        }

        public class AddSubjectsCommandHandler : BaseRequestHandler, IRequestHandler<AddSubjectsCommand, StudentSubjects>
        {
            //private readonly IMediator mediator;
            public AddSubjectsCommandHandler(IStudentEnrollmentSystemDbContext dbContext) : base(dbContext)
            {
                //this.mediator = mediator;
            }

            public async Task<StudentSubjects> Handle(AddSubjectsCommand request, CancellationToken cancellationToken)
            {
                StudentSubjects _studentSubjectsID = dbContext.StudentSubjects.Find(request._subjectID);

                return _studentSubjectsID;
            }
        }
    }
}
