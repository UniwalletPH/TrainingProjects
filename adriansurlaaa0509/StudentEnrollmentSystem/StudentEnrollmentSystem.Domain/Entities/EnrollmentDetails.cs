﻿using StudentEnrollmentSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentEnrollmentSystem.Domain.Entities
{
    public class EnrollmentDetails
    {
        [Key]
        public int ID { get; set; }

        public string enrollmentSemester { get; set; }
        public string enrollmentYear { get; set; }

    }
}
