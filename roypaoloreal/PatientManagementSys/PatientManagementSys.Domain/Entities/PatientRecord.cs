using System;
using System.Collections.Generic;
using System.Text;

namespace PatientManagementSys.Domain.Entities
{
    public class PatientRecords
    {
        public long ID { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public string diseases { get; set; }

    }
}
