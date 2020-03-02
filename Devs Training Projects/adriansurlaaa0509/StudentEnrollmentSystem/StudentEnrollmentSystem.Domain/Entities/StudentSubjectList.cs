using StudentEnrollmentSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentEnrollmentSystem.Domain.Entities
{
    public class StudentSubjectList
    {
        public int ID { get; set; }

        public int StudentBasicInfoID { get; set; }
     
        public int StudentSubjectsID { get; set; }

        public int EnrollmentDetailsID { get; set; }

        public int StudentProfessorID { get; set; }

    }
}
