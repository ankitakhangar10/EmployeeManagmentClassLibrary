using EmployeeManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> getAllAsync();
        Task AddEmployee(Employee employee) ;
    }
}
