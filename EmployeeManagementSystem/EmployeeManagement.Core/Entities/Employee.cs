using EmployeeManagement.Core.Common;
using EmployeeManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.Core.Entities
{
    public class Employee: BaseEntity
    {
        public string EmployeeCode { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public DateTime DateOfJoining { get; set; }

        public decimal Salary { get; set; }

        public int DesignationId { get; set; } 

        public int DepartmentId { get; set; } 

        public bool IsActive { get; set; } = true;
        public Department Department { get; set; } = null!;
        [MaxLength(500)]
        public string? ProfileImageUrl { get; set; }
        public Designations Designation { get; set; } = null!;
    }
}


