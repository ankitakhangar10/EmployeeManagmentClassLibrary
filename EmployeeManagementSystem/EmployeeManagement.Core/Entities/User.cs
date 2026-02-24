using EmployeeManagement.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core.Entities
{
    public class User: BaseEntity
    {
        public int EmployeeId { get; set; }

        public string Username { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public bool IsActive { get; set; }

        public Employee Employee { get; set; }
    }
}
