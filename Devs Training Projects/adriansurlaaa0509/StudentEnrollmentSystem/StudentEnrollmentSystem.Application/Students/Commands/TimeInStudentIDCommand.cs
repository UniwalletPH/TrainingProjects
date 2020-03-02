using MediatR;
using StudentEnrollmentSystem.Application.Interfaces;
using StudentEnrollmentSystem.Domain.Entities;
using StudentEnrollmentSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentEnrollmentSystem.Application.Students.Commands
{
    public class TimeInStudentIDCommand : IRequest<bool>
    {
        private readonly int studID;

        public TimeInStudentIDCommand(int studID)
        {
            this.studID = studID;
        }

        public class TimeInStudentIDCommandHandler : IRequestHandler<TimeInStudentIDCommand, bool>
        {
            private readonly IStudentEnrollmentSystemDbContext dbContext;
            public TimeInStudentIDCommandHandler(IStudentEnrollmentSystemDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(TimeInStudentIDCommand request, CancellationToken cancellationToken)
            {
                var _dateNow = DateTime.Now.Date;
                //DateTime from = Convert.ToDateTime("00:00:01");
                //DateTime to = Convert.ToDateTime("11:59:59");


                StudentBasicInfo _checkStudentID = dbContext.StudentBasicInfos.Find(request.studID);
                if (_checkStudentID == null)
                {
                    throw new Exception("Student ID does not exist!");
                }

                var _checkTimeInToday = dbContext.StudentDailyTimeRecords.Select(a => a.StudentBasicInfoID == request.studID && a.StudentTimeIn.Date == _dateNow).ToList();

                if (_checkTimeInToday.Count() > 0)
                {
                    throw new Exception("Student ID has already timed in!");
                }

                StudentDailyTimeRecord _studentTimeIn = new StudentDailyTimeRecord
                {
                    StudentBasicInfoID = request.studID,
                    StudentTimeIn = DateTime.Now
                };

                dbContext.StudentDailyTimeRecords.Add(_studentTimeIn);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
