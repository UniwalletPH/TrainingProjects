using MediatR;
using StudentEnrollmentSystem.Application.Common.Base;
using StudentEnrollmentSystem.Application.Interfaces;
using StudentEnrollmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentEnrollmentSystem.Application.SEScrudCommands
{
    public class AddSubjectDetailsCommand : IRequest<int>
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

        public class AddSubjectDetailsCommandHandler : BaseRequestHandler, IRequestHandler<AddSubjectDetailsCommand, bool>
        {
            public AddSubjectDetailsCommandHandler(IStudentEnrollmentSystemDbContext dbContext) : base(dbContext)
            {

            }

            public async Task<bool> Handle(AddSubjectDetailsCommand request, CancellationToken cancellationToken)
            {
                StudentSubjectList _studentSubjectList = new StudentSubjectList
                {
                    StudentBasicInfoID = request.studentBasicInfo,
                    StudentSubjectsID = request.subjectID,
                    StudentProfessorID = request.studentProfessor.ID,
                    EnrollmentDetailsID = request.enrollmentDetails.ID
                };

                dbContext.StudentSubjectLists.Add(_studentSubjectList);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
