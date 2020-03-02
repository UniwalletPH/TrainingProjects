using EManager.Domain.Enums;
using System.Collections.Generic;

namespace EManager.Domain.Entities
{
    public class EmployeeInformation 
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }              
        public ICollection<EmployeeTimeRecords> EmployeeTimeRecords { get; set; }
    }
}
