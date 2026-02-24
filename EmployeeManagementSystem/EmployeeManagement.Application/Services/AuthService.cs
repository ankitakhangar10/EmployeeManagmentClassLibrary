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
    public class AuthService: IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository,ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public async Task<ApiResponse<bool>> RegisterAsync(RegisterDto dto)
        {
            var response = new ApiResponse<bool>();

            var user = new User
            {
                EmployeeId = dto.EmployeeId,
                Username = dto.Username,
                PasswordHash = dto.Password,
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "System",
                IsDeleted = false
            };

            await _userRepository.AddAsync(user);

            response.Success = true;
            response.Message = "User registered successfully";
            response.Data = true;

            return response;
        }

        public async Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginDto dto)
        {
            var response = new ApiResponse<AuthResponseDto>();

            var user = await _userRepository.GetuserByName(dto.Username);

            if (user == null || user.PasswordHash != dto.Password)
            {
                response.Success = false;
                response.Message = "Invalid username or password";
                return response;
            }

            var token = _tokenService.GenerateToken(user);

            response.Success = true;
            response.Message = "Login successful";
            response.Data = new AuthResponseDto
            {
                Token = token
            };

            return response;
        }
    }
}
