using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;
        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [Authorize]
        [HttpGet("GetAllAttendanceList")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _attendanceService.GetAttendanceList();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        [HttpPost("AddAttendance")]
        public async Task<IActionResult> AddAttendance(AttendanceDto att)
        {
            var result = await _attendanceService.AddAttendance(att);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
