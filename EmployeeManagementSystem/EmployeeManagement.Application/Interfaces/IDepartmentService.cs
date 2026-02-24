using EmployeeManagement.Application.Common;
using EmployeeManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<ApiResponse<List<DepartmentDto>>> GetAllDepartments();
        Task<ApiResponse<int>> AddDepartmes(DepartmentDto department);
    }
}
