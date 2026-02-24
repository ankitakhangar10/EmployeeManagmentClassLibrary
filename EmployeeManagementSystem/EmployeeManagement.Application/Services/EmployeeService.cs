using EmployeeManagement.Application.Common;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Interfaces;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<List<EmployeeDto>>> GetAllAsync()
        {
            var response = new ApiResponse<List<EmployeeDto>>();

            try
            {
                var employees = await _repository.getAllAsync();

                response.Success = true;
                response.Message = "Employees fetched successfully";
                response.Data = employees.Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    EmployeeCode = e.EmployeeCode,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    //Department = e.Department,
                    //Designation = e.Designation,
                    Salary = e.Salary,
                    DateOfJoining = e.DateOfJoining
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
        public async Task<ApiResponse<int>> AddEmployee(EmployeeDto employee)
        {
            var response = new ApiResponse<int>();
            try
            {
                var emp = new Employee
                {
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now,
                    DateOfJoining = employee.DateOfJoining,
                    DepartmentId = employee.DepartmentId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    Salary = employee.Salary,
                    DesignationId = employee.DesignationId,
                    IsActive = true,
                    EmployeeCode = employee.EmployeeCode,
                    IsDeleted = false,

                };
                await _repository.AddEmployee(emp);
                response.Success = true;
                response.Message = " Employee Added";
                response.Data = emp.Id;
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
