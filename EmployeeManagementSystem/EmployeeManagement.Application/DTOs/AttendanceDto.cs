using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeManagement.Application.DTOs
{
    public class AttendanceDto
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public DateTime AttendanceDate { get; set; }
        public DateTime? CheckInTime { get; set; }

        public DateTime? CheckOutTime { get; set; }
        public AttendanceStatus Status { get; set; }

        public decimal? WorkingHours { get; set; }

        public string? Remarks { get; set; }
        public bool IsApproved { get; set; } = false;

    }
}
