using EmployeeManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core.Interfaces
{
    public interface ITokenRepository
    {
        string GenerateToken(User user);
    }
}
