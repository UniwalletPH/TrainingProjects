using System;
using System.Collections.Generic;
using System.Text;
using StudentEnrollmentSystem.Application.Interfaces;

namespace StudentEnrollmentSystem.Application.Common.Base
{
    public class BaseRequestHandler
    {
        internal readonly IStudentEnrollmentSystemDbContext dbContext;

        public BaseRequestHandler(IStudentEnrollmentSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
