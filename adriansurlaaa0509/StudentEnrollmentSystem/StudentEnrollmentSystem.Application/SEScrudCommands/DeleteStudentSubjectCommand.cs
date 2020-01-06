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
using System.Linq;

namespace StudentEnrollmentSystem.Application.SEScrudCommands
{
    public class DeleteStudentSubjectCommand : IRequest<bool>
    {
        private readonly StudentSubjectList myStudentSubjectList;
        //private readonly int selected;
        public DeleteStudentSubjectCommand(StudentSubjectList myStudentSubjectList)
        {
            this.myStudentSubjectList = myStudentSubjectList;
            //this.selected = selected;
        }

        public class DeleteStudentSubjectCommandHandler : BaseRequestHandler, IRequestHandler<DeleteStudentSubjectCommand, bool>
        {
            public DeleteStudentSubjectCommandHandler(IStudentEnrollmentSystemDbContext dbContext) : base(dbContext)
            {

            }

            public async Task<bool> Handle(DeleteStudentSubjectCommand request, CancellationToken cancellationToken)
            {
                var _deleteStudentSubject = dbContext.StudentSubjectLists.Find(request.myStudentSubjectList.ID);

                dbContext.StudentSubjectLists.Remove(_deleteStudentSubject);

                await dbContext.SaveChangesAsync();


                return true;
            }
        }

    }
}
