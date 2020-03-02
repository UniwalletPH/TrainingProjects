using System;
using System.Collections.Generic;
using System.Text;

namespace StudentEnrollmentSystem.Domain.Entities
{
    public class StudentTimeOut
    {
        public int ID { get; set; }
         
        public DateTime StudentTimeOutRecord { get; set; }

        public int StudentBasicInfoID { get; set; }
    }
}
