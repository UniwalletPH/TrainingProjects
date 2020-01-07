using MediatR;

using StudentEnrollmentSystem.Application.Interfaces;
using StudentEnrollmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentEnrollmentSystem.Application.Professors.Commands
{
    public class AddProfessorCommand : IRequest<StudentProfessor>
    {
        private readonly int _professorID;
        public AddProfessorCommand(int _professorID)
        {
            this._professorID = _professorID;
        }

        public class AddProfessorCommandHandler : IRequestHandler<AddProfessorCommand, StudentProfessor>
        {
            private readonly IStudentEnrollmentSystemDbContext dbContext;

            public AddProfessorCommandHandler (IStudentEnrollmentSystemDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<StudentProfessor> Handle(AddProfessorCommand request, CancellationToken cancellationToken)
            {
                StudentProfessor _studentProfessorID = dbContext.StudentProfessors.Find(request._professorID);

                return _studentProfessorID;
            }
        }
    }
}
