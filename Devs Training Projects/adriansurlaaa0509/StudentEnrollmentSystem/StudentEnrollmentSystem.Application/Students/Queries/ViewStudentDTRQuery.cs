using MediatR;
using StudentEnrollmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentEnrollmentSystem.Application.Students.Queries
{
    public class ViewStudentDTRQuery : IRequest<StudentDTR>
    {
        private readonly int studID;
        public ViewStudentDTRQuery(int studID)
        {
            this.studID = studID;
        }

        public class ViewStudentDTRHandler : IRequestHandler<ViewStudentDTRQuery, StudentDTR>
        {
            public async Task<StudentDTR> Handle(ViewStudentDTRQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
