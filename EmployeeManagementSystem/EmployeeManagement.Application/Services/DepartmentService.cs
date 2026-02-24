using EmployeeManagement.Application.Common;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.Services
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;
        public DepartmentService(IDepartmentRepository _departmentRepository)
        {
            departmentRepository = _departmentRepository;
        }
        public async Task<ApiResponse<List<DepartmentDto>>> GetAllDepartments()
        {
            var response = new ApiResponse<List<DepartmentDto>>();
            try
            {
                var departments = await departmentRepository.GetAllDepartment();
                response.Success = true;
                response.Message = "Deprtment List";
                response.Data = departments.Select(e => new DepartmentDto
                {
                    DepartmentCode = e.DepartmentCode,
                    DepartmentName = e.DepartmentName,
                    Id = e.Id,
                    IsActive = e.IsActive
                }).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = null;
            }
            return response;
        }
        public async Task<ApiResponse<int>> AddDepartmes(DepartmentDto dto)
        {
            var response = new ApiResponse<int>();
            try
            {
                var depart = new Department
                {
                    DepartmentCode = dto.DepartmentCode,
                    DepartmentName = dto.DepartmentName,
                    Id = dto.Id,
                    IsActive = dto.IsActive,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Admin"
                };
                await departmentRepository.AddDepartmes(depart);
                response.Success = true;
                response.Message = "Department created successfully";
                response.Data = depart.Id;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
