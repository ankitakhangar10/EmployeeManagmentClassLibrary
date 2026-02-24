using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DTOs
{
    public class DesignationDto
    {
        public int Id { get; set; }
        public string DesignationName { get; set; } = null!;
        public bool IsActive { get; set; } = true;

    }
}
