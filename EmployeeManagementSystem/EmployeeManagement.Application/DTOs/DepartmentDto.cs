using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DTOs
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; } = null!;
        public string DepartmentCode { get; set; } = null!;
        public bool IsActive { get; set; } = true;
    }
}
