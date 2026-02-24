using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class DepartmentRepository: IDepartmentRepository
    {
        private readonly AppDbContext _appDbContext;
        public DepartmentRepository(AppDbContext db)
        {
            _appDbContext = db;
        }
        public async Task<List<Department>> GetAllDepartment ()
        {
            return await _appDbContext.Departments.Where(m => m.IsActive).ToListAsync();
        }
        public async Task AddDepartmes(Department department)
        {
            await _appDbContext.Departments.AddAsync(department);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
