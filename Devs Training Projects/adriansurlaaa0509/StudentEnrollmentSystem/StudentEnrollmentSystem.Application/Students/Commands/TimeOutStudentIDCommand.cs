using MediatR;
using StudentEnrollmentSystem.Application.Interfaces;
using StudentEnrollmentSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentEnrollmentSystem.Application.Students.Commands
{
    public class TimeOutStudentIDCommand : IRequest<DateTime>
    {
        private readonly int studID;

        public TimeOutStudentIDCommand(int studID)
        {
            this.studID = studID;
        }

        public class TimeInStudentIDCommandHandler : IRequestHandler<TimeOutStudentIDCommand, DateTime>
        {
            private readonly IStudentEnrollmentSystemDbContext dbContext;
            public TimeInStudentIDCommandHandler(IStudentEnrollmentSystemDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<DateTime> Handle(TimeOutStudentIDCommand request, CancellationToken cancellationToken)
            {
                var _dateNow = DateTime.Now.Date;
                DateTime _timeOut = Convert.ToDateTime("0001-01-01 00:00:00.0000000");
                ////DateTime from = Convert.ToDateTime("00:00:01");
                ////DateTime to = Convert.ToDateTime("11:59:59");

                //var _checkTimeInToday = dbContext.StudentsTimeIn.Select(a => a.StudentBasicInfoID == request.studID && a.StudentTimeInRecord.Date == _dateNow).ToList();


                var _checkStudentID = dbContext.StudentBasicInfos.Find(request.studID);
                if (_checkStudentID == null)
                {
                    throw new Exception("Student ID does not exist!");
                }


                var _checkTimeOutToday = dbContext.StudentDailyTimeRecords.Select(a => a.StudentBasicInfoID == request.studID && a.StudentTimeOut == _timeOut).ToList();

                if (_checkTimeOutToday.Count() > 1)
                {
                    throw new Exception("Student ID has already timed out!");
                }


                var _getStudentTimeInRecord = dbContext.StudentDailyTimeRecords.Where(a => a.StudentBasicInfoID == request.studID && a.StudentTimeIn == _dateNow).SingleOrDefault();

                var _getStudentIDTimeIn = _getStudentTimeInRecord.StudentBasicInfoID;
                var _getStudentTimeIn = _getStudentTimeInRecord.StudentTimeIn;


                var _deleteStudentTimeIn = dbContext.StudentDailyTimeRecords.Find(_getStudentIDTimeIn);
                dbContext.StudentDailyTimeRecords.Remove(_deleteStudentTimeIn);
                await dbContext.SaveChangesAsync();


                StudentDailyTimeRecord _studentNewRecord = new StudentDailyTimeRecord
                {
                    StudentBasicInfoID = request.studID,
                    StudentTimeIn = _getStudentTimeIn,
                    StudentTimeOut = DateTime.Now
                };

                dbContext.StudentDailyTimeRecords.Add(_studentNewRecord);
                await dbContext.SaveChangesAsync();

                return _getStudentTimeIn;

            }
        }
    }
}
