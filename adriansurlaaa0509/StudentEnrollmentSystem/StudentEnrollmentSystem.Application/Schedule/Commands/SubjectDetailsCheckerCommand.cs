using MediatR;
using StudentEnrollmentSystem.Application.Common.Base;
using StudentEnrollmentSystem.Application.Interfaces;
using StudentEnrollmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentEnrollmentSystem.Application.Schedule.Commands
{
   public class SubjectDetailsCheckerCommand :IRequest <IEnumerable<StudentSubjectList>>
    {
        private readonly int _subject;
        private readonly int _professor;
        private readonly int _schedule;
        public SubjectDetailsCheckerCommand (int _subject, int _professor, int _schedule)
        {
            this._subject = _subject;
            this._professor = _professor;
            this._schedule = _schedule;
        }

        public class SubjectDetailsChecherCommandHandler : IRequestHandler<SubjectDetailsCheckerCommand, IEnumerable<StudentSubjectList>>
        {
            private readonly IStudentEnrollmentSystemDbContext dbContext;
            public SubjectDetailsChecherCommandHandler(IStudentEnrollmentSystemDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<StudentSubjectList>> Handle(SubjectDetailsCheckerCommand request, CancellationToken cancellationToken)
            {
                var _studentSubject = dbContext.StudentSubjectLists.Where(a => a.StudentSubjectsID == request._subject &&
                                                                               a.StudentProfessorID == request._professor &&
                                                                               a.EnrollmentDetailsID == request._schedule).ToList();

                return _studentSubject;
            }
        }
    }
}
