using StudentEnrollmentSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentEnrollmentSystem.Domain.Entities
{
    public class EnrollmentDetails : BaseEntity
    {
        public string enrollmentSemester { get; set; }
        public string enrollmentYear { get; set; }

    }
}
