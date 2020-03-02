using EManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EManager.Application.SystemCommand.Queries
{
    public class UserVM
    {
        public int ID { get; set; }
        
        public string Firstname { get; set; }
        
        public string Lastname { get; set; }

        public string Address { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public UserRole Role { get; set; }

        public LogType LogType { get; set; }
 
    }
}
