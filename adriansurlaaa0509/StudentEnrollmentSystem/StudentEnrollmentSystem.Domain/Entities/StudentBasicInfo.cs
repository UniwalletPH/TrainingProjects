using StudentEnrollmentSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEnrollmentSystem.Domain.Entities
{
    public class StudentBasicInfo : BaseEntity
    {
        public string StudentFirstName { get; set; }

        public string StudentMiddleName { get; set; }

        public string StudentLastName { get; set; }

        public string StudentAge { get; set; }

        public string StudentGender { get; set; }

        public string StudentAddress { get; set; }

        public string StudentEmailAddress { get; set; }

        public string StudentContactNumber { get; set; }

    }
}
