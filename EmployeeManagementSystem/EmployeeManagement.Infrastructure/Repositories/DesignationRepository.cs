using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class DesignationRepository: IDesignationRepository
    {
        private readonly AppDbContext _dbcontext;

        public DesignationRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<Designations>> getAllDesignation()
        {
            return await _dbcontext.designations.Where(m => m.IsActive).ToListAsync();
        }
        public async Task AddDsignation(Designations designation)
        {
            await _dbcontext.designations.AddAsync(designation);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
