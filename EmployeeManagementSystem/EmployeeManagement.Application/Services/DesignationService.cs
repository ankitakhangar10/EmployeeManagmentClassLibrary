using EmployeeManagement.Application.Common;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Interfaces;

namespace EmployeeManagement.Application.Services
{
    public class DesignationService: IDesignationsService
    {
        private readonly IDesignationRepository _IDesignationRepository;
        public DesignationService (IDesignationRepository designationRepository)
        {
            _IDesignationRepository = designationRepository;
        }
        public async Task<ApiResponse<List<DesignationDto>>> getAllDesignation()
        {
            var response = new ApiResponse<List<DesignationDto>>();
            try
            {
                var departments = await _IDesignationRepository.getAllDesignation();
                response.Success = true;
                response.Message = "designation List";
                response.Data = departments.Select(e => new DesignationDto
                {
                    DesignationName = e.DesignationName,
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
        public async Task<ApiResponse<int>> AddDsignation(DesignationDto dto)
        {
            var response = new ApiResponse<int>();
            try
            {
                var designationExist = await _IDesignationRepository.getAllDesignation();
                var isDuplicate =  designationExist.Any(m=>m.DesignationName.ToLower() == dto.DesignationName.ToLower());
                if (isDuplicate)
                {
                    response.Success = false;
                    response.Message = "Designation name already exists.";
                    return response;            
                } else
                {
                    var depart = new Designations
                    {
                        DesignationName = dto.DesignationName,
                        Id = dto.Id,
                        IsActive = dto.IsActive,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "Admin"
                    };
                    await _IDesignationRepository.AddDsignation(depart);
                    response.Success = true;
                    response.Message = "designation created successfully";
                    response.Data = depart.Id;
                }
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
