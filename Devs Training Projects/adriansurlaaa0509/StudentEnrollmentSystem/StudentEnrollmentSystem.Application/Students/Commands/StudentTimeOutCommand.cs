using MediatR;
using StudentEnrollmentSystem.Application.Interfaces;
using StudentEnrollmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentEnrollmentSystem.Application.Students.Commands
{
    public class StudentTimeOutCommand : IRequest<bool>
    {
        private readonly int studID;
        public StudentTimeOutCommand(int studID)
        {
            this.studID = studID;
        }

        public class StudentTimeOutCommandHandler : IRequestHandler<StudentTimeOutCommand, bool>
        {
            private readonly IStudentEnrollmentSystemDbContext dbContext;
            public StudentTimeOutCommandHandler(IStudentEnrollmentSystemDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(StudentTimeOutCommand request, CancellationToken cancellationToken)
            {
                var _dateNow = DateTime.Now.Date;
                //DateTime from = Convert.ToDateTime("00:00:01");
                //DateTime to = Convert.ToDateTime("11:59:59");


                StudentBasicInfo _checkStudentID = dbContext.StudentBasicInfos.Find(request.studID);
                if (_checkStudentID == null)
                {
                    throw new Exception("Student ID does not exist!");
                }

                var _checkStudentTimeIn = dbContext.StudentsTimeIn.Where(a => a.StudentBasicInfoID == request.studID && a.StudentTimeInRecord != _dateNow).SingleOrDefault();
                if (_checkStudentTimeIn == null)
                {
                    throw new Exception("Student ID does not timed in yet!");
                }

                var _checkTimeOutToday = dbContext.StudentsTimeOut.Select(a => a.StudentBasicInfoID == request.studID && a.StudentTimeOutRecord.Date == _dateNow).ToList();

                if (_checkTimeOutToday.Count() > 0)
                {
                    throw new Exception("Student ID has already timed out!");
                }

                StudentTimeOut _studentTimeOut = new StudentTimeOut
                {
                    StudentBasicInfoID = request.studID,
                    StudentTimeOutRecord = DateTime.Now
                };

                dbContext.StudentsTimeOut.Add(_studentTimeOut);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
