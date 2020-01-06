using System;
using System.Collections.Generic;
using System.Text;
using PatientManagementSys.Application.Interfaces;

namespace PatientManagementSys.Application.Common.Base
{
    public class BaseRequestHandler
    {
        internal readonly IPatientManagementSysDbContext dbContext;
        
        public BaseRequestHandler(IPatientManagementSysDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
