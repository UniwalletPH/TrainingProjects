using System;
using System.Collections.Generic;
using System.Text;
using PatientManagementSys.Domain.Entities.Base;
using PatientManagementSys.Enums;

namespace PatientManagementSys.Application.Queries
{
    public class PatientVM : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Diseases { get; set; }
    }
}
