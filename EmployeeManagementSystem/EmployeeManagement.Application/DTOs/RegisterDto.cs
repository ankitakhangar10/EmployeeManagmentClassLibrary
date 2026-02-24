using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DTOs
{
    public class RegisterDto
    {
        public int EmployeeId { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
