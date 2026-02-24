using EmployeeManagement.Application.Common;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EmployeeManagement.Application.Services
{
    public class AttendanceService: IAttendanceService
    {
        private readonly IAttendanceRepository _attendaceRepo;
        public AttendanceService(IAttendanceRepository attendaceRepo)
        {
            _attendaceRepo = attendaceRepo;
        }
        public async Task<ApiResponse<List<AttendanceDto>>> GetAttendanceList()
        {
            var response = new ApiResponse<List<AttendanceDto>>();
            try
            {
                var atte = await _attendaceRepo.GetAllAttendances();
                response.Success = true;
                response.Message = "Attendance Data";
                response.Data = atte.Select(a => new AttendanceDto
                {
                    CheckInTime = a.CheckInTime,
                    EmployeeName = a.Employee.FirstName + " " + a.Employee.LastName,
                    Remarks = a.Remarks,
                    AttendanceDate = a.AttendanceDate,
                    CheckOutTime = a.CheckOutTime,
                    EmployeeId = a.EmployeeId,
                    Id = a.Id,
                    IsApproved = a.IsApproved,
                    Status = a.Status,
                    WorkingHours = a.WorkingHours
                }).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = null;
            }
            return response;
        }
        public async Task<ApiResponse<AttendanceDto>> AddAttendance(AttendanceDto attendance) {
            var res = new ApiResponse<AttendanceDto>();
            try
            {
                var att = new Attendance
                {
                    AttendanceDate = attendance.AttendanceDate,
                    CheckInTime = attendance.CheckInTime,
                    CheckOutTime = attendance.CheckOutTime,
                    EmployeeId = attendance.EmployeeId,
                    IsApproved = attendance.IsApproved,
                    WorkingHours = attendance.WorkingHours,
                    Remarks = attendance.Remarks,
                    Status = attendance.Status,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    ModifiedDate = null,
                    ModifiedBy = null
                };
               await _attendaceRepo.AddAttendance(att);
                res.Success = true;
                res.Message = "Attendancce Added";
                res.Data = attendance;
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }

            return res;
        }
    }
}
