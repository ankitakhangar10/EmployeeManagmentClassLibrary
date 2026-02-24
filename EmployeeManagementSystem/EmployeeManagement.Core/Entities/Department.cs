using EmployeeManagement.Core.Common;
using EmployeeManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.Core.Entities
{
    public class Department: BaseEntity
    {
        [Required(ErrorMessage ="Name is required")]
        public string DepartmentName { get; set; } = null!;
        public string DepartmentCode { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public ICollection<Employee> Employees { get; set; }
    }
}