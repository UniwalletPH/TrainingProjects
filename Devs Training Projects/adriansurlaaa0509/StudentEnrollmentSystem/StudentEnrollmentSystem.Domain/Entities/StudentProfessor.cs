﻿using StudentEnrollmentSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentEnrollmentSystem.Domain.Entities
{
    public class StudentProfessor
    {
        public int ID { get; set; }

        public string ProfName { get; set; }

        public int StudentSubjectsID { get; set; }
    }
}
