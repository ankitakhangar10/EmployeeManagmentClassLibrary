using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string EmployeeCode { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public DateTime DateOfJoining { get; set; }

        public decimal Salary { get; set; }

        public int DesignationId { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public int DepartmentId { get; set; }
    }
}
