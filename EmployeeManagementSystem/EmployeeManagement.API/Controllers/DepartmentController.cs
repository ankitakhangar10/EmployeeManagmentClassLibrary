using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [Authorize]
        [HttpGet("GetAllDepartment")]
        public async Task<IActionResult> GetDepartments() {
            var result = await _departmentService.GetAllDepartments();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        [Authorize]
        [HttpPost("AddDepartment")]
        public async Task<IActionResult> AddDepartment(DepartmentDto dto)
        {
            var result = await _departmentService.AddDepartmes(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
