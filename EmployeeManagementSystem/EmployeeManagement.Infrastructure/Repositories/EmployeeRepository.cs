using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext db)
        {
            _appDbContext = db;
        }
        public async Task<List<Employee>> getAllAsync()
        {
            return await _appDbContext.employees.Where(m => !m.IsDeleted).ToListAsync();
        }
        public async Task AddEmployee(Employee emp)
        {
            await _appDbContext.AddAsync(emp);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
