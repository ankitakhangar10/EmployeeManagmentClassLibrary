using EmployeeManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetAllAttendances();
        Task<Attendance> AddAttendance(Attendance attendance);
    }
}
