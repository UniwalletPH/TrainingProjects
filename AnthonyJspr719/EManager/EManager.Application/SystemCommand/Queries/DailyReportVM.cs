using System;
using System.Collections.Generic;
using System.Text;

namespace EManager.Application.SystemCommand.Queries
{
    public class DailyReportVM
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
    }
}
