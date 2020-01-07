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
    public class FindSemesterQuery : IRequest<EnrollmentDetails>
    {
        private readonly int _schedID;
        public FindSemesterQuery (int _schedID)
        {
            this._schedID = _schedID;
        }

        public class FindSemesterQueryHandler : IRequestHandler<FindSemesterQuery, EnrollmentDetails>
        {
            private readonly IStudentEnrollmentSystemDbContext dbContext;
            public FindSemesterQueryHandler(IStudentEnrollmentSystemDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<EnrollmentDetails> Handle(FindSemesterQuery request, CancellationToken cancellationToken)
            {
                EnrollmentDetails _studentSchedID = dbContext.EnrollmentDetails.Find(request._schedID);

                return _studentSchedID;
            }
        }

    }
}
