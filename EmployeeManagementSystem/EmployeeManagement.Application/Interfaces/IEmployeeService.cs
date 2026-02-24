using EmployeeManagement.Application.Common;
using EmployeeManagement.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<ApiResponse<List<EmployeeDto>>> GetAllAsync();
        Task<ApiResponse<int>> AddEmployee(EmployeeDto employee);
    }
}
