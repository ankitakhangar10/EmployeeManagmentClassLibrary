using EmployeeManagement.Application.Common;
using EmployeeManagement.Application.DTOs;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IDesignationsService
    {
        Task<ApiResponse<List<DesignationDto>>> getAllDesignation();
        Task<ApiResponse<int>> AddDsignation(DesignationDto designation);
    }
}
