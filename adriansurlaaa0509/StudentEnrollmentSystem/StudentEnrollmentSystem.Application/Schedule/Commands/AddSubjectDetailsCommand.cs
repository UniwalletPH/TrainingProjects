using MediatR;

using StudentEnrollmentSystem.Application.Interfaces;
using StudentEnrollmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentEnrollmentSystem.Application.Schedule.Commands
{
    public class AddSubjectDetailsCommand : IRequest<bool>
    {
        private readonly int studentBasicInfo;
        private readonly int subjectID;
        private readonly int professorID;
        private readonly int enrollmentDetailsID;


        public AddSubjectDetailsCommand (int studentBasicInfo, int subjectID, int professorID, int enrollmentDetailsID)
        {
            this.studentBasicInfo = studentBasicInfo;
            this.subjectID = subjectID;
            this.professorID = professorID;
            this.enrollmentDetailsID = enrollmentDetailsID;
        }

        public class AddSubjectDetailsCommandHandler : IRequestHandler<AddSubjectDetailsCommand, bool>
        {
            private readonly IStudentEnrollmentSystemDbContext dbContext;
            public AddSubjectDetailsCommandHandler(IStudentEnrollmentSystemDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddSubjectDetailsCommand request, CancellationToken cancellationToken)
            {
                StudentSubjectList _studentSubjectList = new StudentSubjectList
                {
                    StudentBasicInfoID = request.studentBasicInfo,
                    StudentSubjectsID = request.subjectID,
                    StudentProfessorID = request.professorID,
                    EnrollmentDetailsID = request.enrollmentDetailsID
                };

                dbContext.StudentSubjectLists.Add(_studentSubjectList);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
