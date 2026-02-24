using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationsController : ControllerBase
    {
        private readonly IDesignationsService _desiService;
        public DesignationsController(IDesignationsService designService)
        {
            _desiService = designService;
        }
        [HttpGet("GetAllDesignation")]
        public async Task<IActionResult> GetAllDesignation()
        {
            var result = await _desiService.getAllDesignation();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        [HttpPost("AddDesignation")]
        public async Task<IActionResult> AddDesignation(DesignationDto dto)
        {
            var result = await _desiService.AddDsignation(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

