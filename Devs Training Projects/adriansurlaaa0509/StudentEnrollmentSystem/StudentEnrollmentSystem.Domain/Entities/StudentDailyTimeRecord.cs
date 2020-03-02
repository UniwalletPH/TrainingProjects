using System;
using System.Collections.Generic;
using System.Text;

namespace StudentEnrollmentSystem.Domain.Entities.Base
{
    public class StudentDailyTimeRecord
    {

        public int ID { get; set; }

        public int StudentBasicInfoID { get; set; }

        public DateTime StudentTimeIn { get; set; }

        public DateTime StudentTimeOut { get; set; }

    }
}
