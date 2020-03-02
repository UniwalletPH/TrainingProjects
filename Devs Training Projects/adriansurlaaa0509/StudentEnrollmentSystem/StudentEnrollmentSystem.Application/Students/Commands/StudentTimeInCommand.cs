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
    public class StudentTimeInCommand : IRequest<bool>
    {
        private readonly int studID;
        public StudentTimeInCommand(int studID)
        {
            this.studID = studID;
        }

        public class StudentTimeInCommandHandler : IRequestHandler<StudentTimeInCommand, bool>
        {
            private readonly IStudentEnrollmentSystemDbContext dbContext;
            public StudentTimeInCommandHandler(IStudentEnrollmentSystemDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(StudentTimeInCommand request, CancellationToken cancellationToken)
            {
                var _dateNow = DateTime.Now.Date;
                //DateTime from = Convert.ToDateTime("00:00:01");
                //DateTime to = Convert.ToDateTime("11:59:59");


                StudentBasicInfo _checkStudentID = dbContext.StudentBasicInfos.Find(request.studID);
                if (_checkStudentID == null)
                {
                    throw new Exception("Student ID does not exist!");
                }

                var _checkTimeInToday = dbContext.StudentsTimeIn.Select(a => a.StudentBasicInfoID == request.studID && a.StudentTimeInRecord.Date == _dateNow).ToList();

                if (_checkTimeInToday.Count() > 0)
                {
                    throw new Exception("Student ID has already timed out!");
                }

                StudentTimeIn _studentTimeIn = new StudentTimeIn
                {
                    StudentBasicInfoID = request.studID,
                    StudentTimeInRecord = DateTime.Now
                };

                dbContext.StudentsTimeIn.Add(_studentTimeIn);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
