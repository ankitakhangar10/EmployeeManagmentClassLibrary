using EmployeeManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetuserByName(string username);
        Task AddAsync(User user);
    }
}
