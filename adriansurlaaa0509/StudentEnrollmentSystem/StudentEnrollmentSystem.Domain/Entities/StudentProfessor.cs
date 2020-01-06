using StudentEnrollmentSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentEnrollmentSystem.Domain.Entities
{
    public class StudentProfessor : BaseEntity
    {

        public string ProfName { get; set; }

        public int StudentSubjectsID { get; set; }

    }
}
