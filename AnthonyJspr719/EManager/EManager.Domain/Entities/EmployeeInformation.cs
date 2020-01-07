using EManager.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EManager.Domain.Entities
{
    public class EmployeeInformation 
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public ICollection<EmployeeTimeRecords> EmployeeTimeRecords { get; set; }
    }
}
