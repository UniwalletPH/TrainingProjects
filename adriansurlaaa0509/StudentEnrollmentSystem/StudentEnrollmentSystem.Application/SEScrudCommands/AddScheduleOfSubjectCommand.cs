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
    public class AddScheduleOfSubjectCommand : IRequest<EnrollmentDetails>
    {
        private readonly int _schedID;
        public AddScheduleOfSubjectCommand (int _schedID)
        {
            this._schedID = _schedID;
        }

        public class AddScheduleOfSubjectCommandHandler : BaseRequestHandler, IRequestHandler<AddScheduleOfSubjectCommand, EnrollmentDetails>
        {
            public AddScheduleOfSubjectCommandHandler(IStudentEnrollmentSystemDbContext dbContext) : base(dbContext)
            {

            }
            public async Task<EnrollmentDetails> Handle(AddScheduleOfSubjectCommand request, CancellationToken cancellationToken)
            {
                EnrollmentDetails _studentSchedID = dbContext.EnrollmentDetails.Find(request._schedID);

                return _studentSchedID;
            }
        }

    }
}
