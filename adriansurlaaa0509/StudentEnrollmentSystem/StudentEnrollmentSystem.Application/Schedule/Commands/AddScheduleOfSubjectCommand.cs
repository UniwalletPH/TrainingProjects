using MediatR;
using StudentEnrollmentSystem.Application.Common.Base;
using StudentEnrollmentSystem.Application.Interfaces;
using StudentEnrollmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentEnrollmentSystem.Application.Schedule.Commands
{
    public class AddScheduleOfSubjectCommand : IRequest<EnrollmentDetails>
    {
        private readonly int _schedID;
        public AddScheduleOfSubjectCommand (int _schedID)
        {
            this._schedID = _schedID;
        }

        public class AddScheduleOfSubjectCommandHandler : IRequestHandler<AddScheduleOfSubjectCommand, EnrollmentDetails>
        {
            private readonly IStudentEnrollmentSystemDbContext dbContext;
            public AddScheduleOfSubjectCommandHandler(IStudentEnrollmentSystemDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<EnrollmentDetails> Handle(AddScheduleOfSubjectCommand request, CancellationToken cancellationToken)
            {
                EnrollmentDetails _studentSchedID = dbContext.EnrollmentDetails.Find(request._schedID);

                return _studentSchedID;
            }
        }

    }
}
