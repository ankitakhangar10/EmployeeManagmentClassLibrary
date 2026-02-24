using EmployeeManagement.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core.Entities
{
    public class Designations : BaseEntity
    {
        public string DesignationName { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public ICollection<Employee> Employees { get; set; }
    }
}
