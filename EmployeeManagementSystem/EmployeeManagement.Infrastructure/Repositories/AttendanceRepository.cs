using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AppDbContext _appDbContext;
        public AttendanceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Attendance>> GetAllAttendances()
        {
            return await _appDbContext.Attendances.Include(m => m.Employee).ToListAsync();
        }
        public async Task<Attendance> AddAttendance(Attendance attendance)
        {
            await _appDbContext.Attendances.AddAsync(attendance);
            await _appDbContext.SaveChangesAsync();
            return attendance;
        }
    }
}
