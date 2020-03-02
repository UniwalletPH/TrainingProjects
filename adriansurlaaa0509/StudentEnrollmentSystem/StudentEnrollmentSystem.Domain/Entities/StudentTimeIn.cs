using System;
using System.Collections.Generic;
using System.Text;

namespace StudentEnrollmentSystem.Domain.Entities
{
    public class StudentTimeIn
    {
        public int ID { get; set; }

        public DateTime StudentTimeInRecord { get; set; }

        public int StudentBasicInfoID { get; set; }
    }
}
