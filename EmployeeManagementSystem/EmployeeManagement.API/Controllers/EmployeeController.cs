using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("GetAllEmployee")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _employeeService.GetAllAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> AddEmployee(EmployeeDto emp)
        {
            var result = await _employeeService.AddEmployee(emp);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
