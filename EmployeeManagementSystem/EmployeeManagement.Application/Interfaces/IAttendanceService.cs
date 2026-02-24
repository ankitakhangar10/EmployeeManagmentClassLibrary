using EmployeeManagement.Application.Common;
using EmployeeManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IAttendanceService
    {
       Task<ApiResponse<List<AttendanceDto>>> GetAttendanceList();
        Task<ApiResponse<AttendanceDto>> AddAttendance(AttendanceDto attendance);
    }
}
