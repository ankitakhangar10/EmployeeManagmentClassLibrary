using EmployeeManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllDepartment();
        Task AddDepartmes(Department department);

    }
}
