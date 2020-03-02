using MediatR;
using StudentEnrollmentSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using StudentEnrollmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace StudentEnrollmentSystem.Application.Students.Commands
{
    public class DeleteStudentInfoCommand : IRequest<bool>
    {
        private readonly int deleteSearchedID;
        public DeleteStudentInfoCommand(int deleteSearchedID)
        {
            this.deleteSearchedID = deleteSearchedID;
        }

        public class DeleteStudentInfoCommandHandler : IRequestHandler<DeleteStudentInfoCommand, bool>
        {
            private readonly IStudentEnrollmentSystemDbContext dbContext;
            public DeleteStudentInfoCommandHandler(IStudentEnrollmentSystemDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(DeleteStudentInfoCommand request, CancellationToken cancellationToken)
            {
                var _deleteStudentInfo = dbContext.StudentSubjectLists.Find(request.deleteSearchedID);

                if (_deleteStudentInfo != null)
                {
                    dbContext.StudentSubjectLists.Remove(_deleteStudentInfo);
                }
                else
                {
                    throw new Exception("Student ID does not exist!");
                }


                await dbContext.SaveChangesAsync();


                return true;
            }
        }
    }
}
