using EManager.Domain.Entities.Base;
using EManager.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EManager.Domain.Entities
{
    public class EmployeeTimeRecords : BaseEntity
    {
       
        public DateTime Time { get; set; }
        public RecordType RecordType { get; set; }

        public int EmployeeInformationID { get; set; }
        public EmployeeInformation EmployeeInformation { get; set; }
        
    }
}
