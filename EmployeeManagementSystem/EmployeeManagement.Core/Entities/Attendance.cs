using EmployeeManagement.Core.Common;
using EmployeeManagement.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeManagement.Core.Entities
{
    public class Attendance: BaseEntity
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime AttendanceDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CheckInTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CheckOutTime { get; set; }

        [Required]
        [MaxLength(20)]
        public AttendanceStatus Status { get; set; } 
        // Present, Absent, Leave, HalfDay

        [Column(TypeName = "decimal(5,2)")]
        public decimal? WorkingHours { get; set; }

        [MaxLength(250)]
        public string? Remarks { get; set; }
        public bool IsApproved { get; set; } = false;

        // Navigation Property
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; } = null!;
    }
}
