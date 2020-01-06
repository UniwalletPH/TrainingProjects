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
    public class AddSubjectDetailsCommand : IRequest<bool>
    {
        private readonly int studentBasicInfo; 
        private readonly StudentSubjects studentSubject;
        private readonly StudentProfessor studentProfessor;
        private readonly EnrollmentDetails enrollmentDetails;

        public AddSubjectDetailsCommand (int studentBasicInfo, StudentSubjects studentSubject, StudentProfessor studentProfessor, EnrollmentDetails enrollmentDetails)
        {
            this.studentBasicInfo = studentBasicInfo;
            this.studentSubject = studentSubject;
            this.studentProfessor = studentProfessor;
            this.enrollmentDetails = enrollmentDetails;
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
                    StudentSubjectsID = request.studentSubject.ID,
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
